﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Features.Characters.Model
{
    public class CharactersListViewModel
    {
        public IEnumerable<CharactersListItem> Characters { get; set; }
    }
}