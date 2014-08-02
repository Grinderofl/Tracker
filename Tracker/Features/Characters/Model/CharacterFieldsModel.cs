using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Features.Core.Extensions;
using Core.Domain;

namespace Tracker.Features.Characters.Model
{
    public class CharacterFieldsModel
    {
        public IEnumerable<SelectListItem> PossibleClasses
        {
            get { return Classes.DeathKnight.ToSelectList(); }
        }

        public IEnumerable<SelectListItem> PossibleRaces
        {
            get { return Races.BloodElf.ToSelectList(); }
        }

        public string Class { get; set; }
        public string Race { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
    }
}