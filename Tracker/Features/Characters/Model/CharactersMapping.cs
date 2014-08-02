using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Domain;

namespace Tracker.Features.Characters.Model
{
    public class CharactersProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Character, CharactersListItem>();
            CreateMap<CharacterFieldsModel, Character>();
            CreateMap<Character, CharacterFieldsModel>();

        }
    }
}