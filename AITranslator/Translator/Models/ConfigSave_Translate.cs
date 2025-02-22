﻿using AITranslator.Translator.TranslateData;
using AITranslator.View.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITranslator.Translator.Models
{
    /// <summary>
    /// 用于保存配置到本地的类
    /// </summary>
    public class ConfigSave_Translate
    {       
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 翻译模板配置
        /// </summary>
        public string? TemplateConfig { get; set; }
        /// <summary>
        /// 翻译类型
        /// </summary>
        public TranslateDataType TranslateType { get; set; }
        /// <summary>
        /// 进度
        /// </summary>
        public double Progress { get; set; }
        /// <summary>
        /// 替换文本
        /// </summary>
        public Dictionary<string, string> Replaces { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 当前任务状态
        /// </summary>
        public TaskState State { get; set; }
    }
}
