using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Features.Characters.Model
{
    public class CharacterListFieldsModel
    {
        public IEnumerable<string> Name { get; set; }
        public IEnumerable<string> Class { get; set; }
        public IEnumerable<string> Race { get; set; }
    }
}