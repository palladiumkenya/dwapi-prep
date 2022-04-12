﻿using System.Threading;
using System.Threading.Tasks;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.SharedKernel.Exceptions;
using Dwapi.Prep.SharedKernel.Model;
using MediatR;

namespace Dwapi.Prep.Core.Command
{

    public class VerifySubscriber : IRequest<VerificationResponse>
    {
        public string DocketId { get; set; }
        public string SubscriberId { get; }
        public string AuthToken { get; }

        public VerifySubscriber(string subscriberId, string authToken, string docketId = "PREP")
        {
            DocketId = docketId;
            SubscriberId = subscriberId;
            AuthToken = authToken;
        }
    }
    public class VerifySubscriberHandler : IRequestHandler<VerifySubscriber, VerificationResponse>
    {
        private readonly IDocketRepository _repository;

        public VerifySubscriberHandler(IDocketRepository repository)
        {
            _repository = repository;
        }


        public async Task<VerificationResponse> Handle(VerifySubscriber request, CancellationToken cancellationToken)
        {
            var docket = await _repository.FindAsync(request.DocketId);

            if (null == docket)
                throw new DocketNotFoundException(request.DocketId);

            if (!docket.SubscriberExists(request.SubscriberId))
                throw new SubscriberNotFoundException(request.SubscriberId);

            if (docket.SubscriberAuthorized(request.SubscriberId, request.AuthToken))
                    return new VerificationResponse(docket.Name,true);

            throw new SubscriberNotAuthorizedException(request.SubscriberId);
        }
    }
}
