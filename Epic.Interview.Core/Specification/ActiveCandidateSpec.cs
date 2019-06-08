using System;
using System.Linq.Expressions;
using Epic.Common.Query;
using Epic.Interview.Core.Domain.Entities;

namespace Epic.Interview.Core.Specification
{
    public class ActiveCandidateSpec : Specification<Candidate>
    {
        public override Expression<Func<Candidate, bool>> Spec => candidate => candidate.Active;
    }
}