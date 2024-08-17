using Application.Details.Get;
using Application.Transactions.Histories;
using Application.Transactions.Payment.Create;
using Application.Transactions.Purchase.Create;
using Application.Transactions.Purchase.Get;
using AutoMapper;
using Domain.Details;
using Domain.Transactions;
using Web.Api.Controllers.Transactions.Request;

namespace Application.Abstractions.Mapping;

public class ApplicationMapping : Profile
{
    public ApplicationMapping()
    {
        Mapping();
    }

    private void Mapping()
    {
        CreateMap<DetailsCard, DetailsResponse>();
        CreateMap<PaymentRequest, CreatePaymentCommand>();
        CreateMap<PurchaseRequest, CreatePurchaseCommand>();

        CreateMap<History, HistoryResponse>()
            .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.card_number))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.payment_date))
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.transaction_type));
        
        CreateMap<Purchase, PurchaseResponse>()
            .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.card_number))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.payment_date))
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.transaction_type));

        CreateMap<CreatePurchaseCommand, Purchase>()
            .ForMember(dest => dest.card_number, opt => opt.MapFrom(src => src.CardNumber))
            .ForMember(dest => dest.payment_date, opt => opt.MapFrom(src => src.PaymentDate))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<CreatePaymentCommand, Payment>()
            .ForMember(dest => dest.card_number, opt => opt.MapFrom(src => src.CardNumber))
            .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.payment_date, opt => opt.MapFrom(src => src.PaymentDate));
       
    }
}
