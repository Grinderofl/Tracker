using AutoMapper;
using Core.Domain;
using Tracker.Features.Characters.Model;

namespace Tracker.Features.Core.Mapping
{
    public class CharactersMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Character, CharactersListItem>();
            CreateMap<CharacterFieldsModel, Character>();
            CreateMap<Character, CharacterFieldsModel>();
        }
    }
}