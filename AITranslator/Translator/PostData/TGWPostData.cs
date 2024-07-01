﻿using AITranslator.Translator.Models;
using AITranslator.Translator.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITranslator.Translator.PostData
{
    /// <summary>
    /// 发送至AI翻译服务的数据类
    /// </summary>
    public class TGWPostData : PostDataBase
    {
        public string mode { get; set; } = "instruct";
        public string instruction_template { get; set; } = "ChatML";
    }
}
