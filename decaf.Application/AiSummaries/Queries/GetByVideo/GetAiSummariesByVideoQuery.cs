using decaf.Application.AiSummaries.Common;
using MediatR;

namespace decaf.Application.AiSummaries.Queries.GetByVideo;

public class GetAiSummariesByVideoQuery : IRequest<List<AiSummaryDto>>
{
    public int VideoId { get; set; }
}