﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITranslator.View.Models
{
    public partial class ViewModel_TaskConfigView : ViewModel_ValidateBase
    {        /// <summary>
             /// 是否是英语翻译
             /// </summary>
        [ObservableProperty]
        private bool isEnglish;

        /// <summary>
        /// 上下文记忆数量
        /// </summary>
        [Range(typeof(uint), "0", "50", ErrorMessage = "上下文记忆数量超过限制！")]
        [ObservableProperty]
        private uint historyCount = 5;

        /// <summary>
        /// 文本替换列表
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<KeyValueStr> replaces = new ObservableCollection<KeyValueStr>();


        public ViewModel_TaskConfigView() { }


        /// <summary>
        /// 主动校验设置界面是否存在错误
        /// </summary>
        /// <returns></returns>
        public override bool ValidateError()
        {
            ICollection<ValidationResult> results = new List<ValidationResult>();

            bool b = Validator.TryValidateObject(this, new ValidationContext(this), results, true);

            Dictionary<string, object> keys = new Dictionary<string, object>();
            foreach (var replace in Replaces)
            {
                if (!string.IsNullOrWhiteSpace(replace.Key))
                {
                    if (!keys.ContainsKey(replace.Key))
                        keys[replace.Key] = null;
                    else
                    {
                        results.Add(new ValidationResult("存在重复的被替换字"));
                        break;
                    }
                }
                else
                {
                    results.Add(new ValidationResult("存在空被替换字"));
                    break;
                }
            }

            Error = results.Count != 0;
            ErrorMessage = string.Join("\r\n", results.Select(s => s.ErrorMessage));
            return b;
        }

        public void CopyTo(TranslationTask task)
        {
            task.Replaces.Clear();
            foreach (var replace in Replaces)
                task.Replaces.Add(replace);
            task.HistoryCount = HistoryCount;
            task.IsEnglish = IsEnglish;
        }

        public static ViewModel_TaskConfigView Create(TranslationTask task)
        {
            ViewModel_TaskConfigView vm = new ViewModel_TaskConfigView()
            {
                HistoryCount = task.HistoryCount,
                IsEnglish = task.IsEnglish
            };
            foreach (var replace in task.Replaces)
                vm.Replaces.Add(replace);
            return vm;
        }
    }
}
