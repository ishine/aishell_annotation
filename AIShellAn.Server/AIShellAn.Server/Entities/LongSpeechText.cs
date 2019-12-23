using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    public class LongSpeechText
    {
        [Key]
        public Guid Id { get; set; }

        public int Order { get; set; }


        public Guid LongSpeechItemId { get; set; }

        public LongSpeechItem LongSpeechItem { get; set; }

        [MaxLength(200)]
        public string Text { get; set; }
    }
}
