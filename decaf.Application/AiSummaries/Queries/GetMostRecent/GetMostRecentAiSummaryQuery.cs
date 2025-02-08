using decaf.Application.AiSummaries.Common;
using MediatR;

namespace decaf.Application.AiSummaries.Queries.GetMostRecent;

public class GetMostRecentAiSummaryQuery : IRequest<AiSummaryDto?>
{
    public int VideoId { get; set; }
}