﻿using System.Runtime.InteropServices;

namespace LLamaSelect
{
    public static class LLamaSelector
    {
        [DllImport("CUDA/cudart64_12.dll")] // 假设你使用的是CUDA 10.0版本
        private static extern int cudaDriverGetVersion(out int version);

        public static string GetLLamaPath()
        {
            cudaDriverGetVersion(out int driverVersion);

            if (driverVersion > 12000)
                return "CUDA/llama.dll";
            else
                return "OpenCL/llama.dll";
        }
    }
}
