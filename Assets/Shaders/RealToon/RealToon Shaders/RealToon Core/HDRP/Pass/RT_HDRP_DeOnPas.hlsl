//RealToon HDRP - DeOnPas
//MJQStudioWorks

#include "Assets/RealToon/RealToon Shaders/RealToon Core/HDRP/RT_HDRP_Other.hlsl"

#if (SHADERPASS != SHADERPASS_DEPTH_ONLY && SHADERPASS != SHADERPASS_SHADOWS)
	#error SHADERPASS_is_not_correctly_define
#endif

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/VertMesh.hlsl"

PackedVaryingsType Vert(AttributesMesh inputMesh)
{
	VaryingsType varyingsType;

#if defined(HAVE_RECURSIVE_RENDERING)

	if (_EnableRecursiveRayTracing && _RecurRen > 0.0)
	{
		ZERO_INITIALIZE(VaryingsType, varyingsType);
	}
	else
#endif
	{
		varyingsType.vmesh = VertMesh(inputMesh);
	}

	return PackVaryingsType(varyingsType);
}

			
void Frag(  PackedVaryingsToPS packedInput
			#ifdef WRITE_NORMAL_BUFFER
			, out float4 outNormalBuffer : SV_Target0
				#ifdef WRITE_MSAA_DEPTH
				, out float1 depthColor : SV_Target1
				#endif
			#elif defined(WRITE_MSAA_DEPTH) 
			, out float4 outNormalBuffer : SV_Target0
			, out float1 depthColor : SV_Target1
			#elif defined(SCENESELECTIONPASS)
			, out float4 outColor : SV_Target0
			#endif

			#ifdef _DEPTHOFFSET_ON
			, out float outputDepth : SV_Depth
			#endif
		)
{
	UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(packedInput);
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

	#if N_F_NM_ON

		float3 normalTS = float3(0.0,0.0,0.0);

		normalTS = RT_NM(input.texCoord0.xy);

		surfaceData.perceptualSmoothness = _Smoothness;
		surfaceData.normalWS = SafeNormalize(TransformTangentToWorld(normalTS, input.tangentToWorld));

	#endif

	//RT CO ONLY
	RT_CO_ONLY(input.texCoord0.xy);

#ifdef _DEPTHOFFSET_ON
	outputDepth = posInput.deviceDepth;
#endif

#ifdef WRITE_NORMAL_BUFFER
	EncodeIntoNormalBuffer(ConvertSurfaceDataToNormalData(surfaceData), posInput.positionSS, outNormalBuffer);
	#ifdef WRITE_MSAA_DEPTH
	depthColor = packedInput.vmesh.positionCS.z;
	#endif
#elif defined(WRITE_MSAA_DEPTH)
	outNormalBuffer = float4(0.0, 0.0, 0.0, 1.0);
	depthColor = packedInput.vmesh.positionCS.z;
#elif defined(SCENESELECTIONPASS)
	outColor = float4(_ObjectId, _PassValue, 1.0, 1.0);
#endif

}