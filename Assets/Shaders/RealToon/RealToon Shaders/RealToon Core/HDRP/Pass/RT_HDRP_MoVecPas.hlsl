//RealToon HDRP - MoVecPas
//MJQStudioWorks

#include "Assets/RealToon/RealToon Shaders/RealToon Core/HDRP/RT_HDRP_Other.hlsl"

#if SHADERPASS != SHADERPASS_MOTION_VECTORS
#error SHADERPASS_is_not_correctly_define
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/MotionVectorVertexShaderCommon.hlsl"

PackedVaryingsType Vert(AttributesMesh inputMesh,
						AttributesPass inputPass)
{
	VaryingsType varyingsType;
	varyingsType.vmesh = VertMesh(inputMesh);

	return MotionVectorVS(varyingsType, inputMesh, inputPass);
}

void Frag(  PackedVaryingsToPS packedInput
			, out float4 outMotionVector : SV_Target0
			#ifdef WRITE_NORMAL_BUFFER
			, out float4 outNormalBuffer : SV_Target1
				#ifdef WRITE_MSAA_DEPTH
				, out float1 depthColor : SV_Target2
				#endif
			#elif defined(WRITE_MSAA_DEPTH) 
			, out float4 outNormalBuffer : SV_Target1
			, out float1 depthColor : SV_Target2
			#endif

			#ifdef _DEPTHOFFSET_ON
			, out float outputDepth : SV_Depth
			#endif
		)
{
	FragInputs input = UnpackVaryingsMeshToFragInputs(packedInput.vmesh);

	PositionInputs posInput = GetPositionInput(input.positionSS.xy, _ScreenSize.zw, input.positionSS.z, input.positionSS.w, input.positionRWS);

#ifdef VARYINGS_NEED_POSITION_WS
	float3 V = GetWorldSpaceNormalizeViewDir(input.positionRWS);
#else
	float3 V = float3(1.0, 1.0, 1.0);
#endif

	SurfaceData surfaceData;
	BuiltinData builtinData;
	GetSurfaceAndBuiltinData(input, V, posInput, surfaceData, builtinData);

	//RT CO ONLY
	RT_CO_ONLY(input.texCoord0.xy);

	VaryingsPassToPS inputPass = UnpackVaryingsPassToPS(packedInput.vpass);
#ifdef _DEPTHOFFSET_ON
	inputPass.positionCS.w += builtinData.depthOffset;
	inputPass.previousPositionCS.w += builtinData.depthOffset;
#endif

	float2 motionVector = CalculateMotionVector(inputPass.positionCS, inputPass.previousPositionCS);

	EncodeMotionVector(motionVector * 0.5, outMotionVector);

	bool forceNoMotion = unity_MotionVectorsParams.y == 0.0;

	if (forceNoMotion)
		outMotionVector = float4(2.0, 0.0, 0.0, 0.0);

#ifdef WRITE_NORMAL_BUFFER
	EncodeIntoNormalBuffer(ConvertSurfaceDataToNormalData(surfaceData), posInput.positionSS, outNormalBuffer);
	#ifdef WRITE_MSAA_DEPTH
	depthColor = packedInput.vmesh.positionCS.z;
	#endif
#elif defined(WRITE_MSAA_DEPTH) 
	outNormalBuffer = float4(0.0, 0.0, 0.0, 1.0);
	depthColor = packedInput.vmesh.positionCS.z;
#endif

#ifdef _DEPTHOFFSET_ON
	outputDepth = posInput.deviceDepth;
#endif
}
