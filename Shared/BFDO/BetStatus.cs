﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shared.BFDO
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BetStatus
    {
        SETTLED,
        VOIDED,
        LAPSED,
        CANCELLED,
    }
}