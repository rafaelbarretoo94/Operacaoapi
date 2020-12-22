using AutoMapper;
using Domain.Models;
using Vendas.Controllers;
using Vendas.Models;

namespace Vendas
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<VendaPost, Venda>().
                ForMember(destino => destino.Id, origem => origem.MapFrom(a => a.Id))
                .ForMember(destino => destino.Status, origem => origem.MapFrom(a => a.Status))
                .ForMember(destino => destino.DataVenda, origem => origem.MapFrom(a => a.DataVenda));

            CreateMap<VendedorPost, Vendedor>().
                ForMember(destino => destino.Id, origem => origem.MapFrom(a => a.Id))
                .ForMember(destino => destino.Cpf, origem => origem.MapFrom(a => a.Cpf))
                .ForMember(destino => destino.Nome, origem => origem.MapFrom(a => a.Nome))
                .ForMember(destino => destino.Telefone, origem => origem.MapFrom(a => a.Telefone))
                .ForMember(destino => destino.Email, origem => origem.MapFrom(a => a.Email));

            CreateMap<ItemVendaPost, ItemVenda>()
            .ForMember(destino => destino.Id, origem => origem.MapFrom(a => a.Id))
            .ForMember(destino => destino.NomeProduto, origem => origem.MapFrom(a => a.NomeProduto));

            CreateMap<StatusVendaPost, StatusVenda>();

            CreateMap<Venda, VendaGet>();
            CreateMap<ItemVendaPost, ItemVendaGet>();
        }
    }
}
