﻿using System.Xml.Linq;

namespace InvelopContactManager.Domain.Models
{
    public class BaseResponse
    {
        public bool IsOk { get; set; }

        public string? Message { get; set; }
    }

    public class BaseResponse<TResult>
    {
        public bool IsOk { get; set; } = true;

        public string? Message { get; set; }

        public TResult? Result { get; set; }
    }
}