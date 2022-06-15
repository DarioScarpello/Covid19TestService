﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Covid19TestService_Library.Models
{
    public partial class Antigen
    {
        public int Aid { get; set; }
        public int? Lines { get; set; }
        public DateTime? Takenon { get; set; }
        public bool? Ispositive { get; set; }
        public int? Pid { get; set; }

        public Antigen()
        {

        }

        [JsonIgnore]
        public virtual Profile PidNavigation { get; set; }

        public Antigen(int aid, int? lines, DateTime? takenon, bool? ispositive, int? pid)
        {
            Aid = aid;
            Lines = lines;
            Takenon = takenon;
            Ispositive = ispositive;
            Pid = pid;
        }
    }
}