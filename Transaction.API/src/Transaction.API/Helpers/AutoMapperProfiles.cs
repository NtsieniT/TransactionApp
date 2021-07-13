using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transaction.API.DTOs;
using Transaction.Domain.Models;

namespace Transaction.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Transactions, TransactionWithTypeDto>()
                .ForMember(dest => dest.Type, option =>
                {
                    option.MapFrom(src => src.Type.Description);
                })
                .ForMember(destination => destination.TypeId,
                options => {
                    options.MapFrom(source => source.Type.Id);
                });
        }
    }
}
