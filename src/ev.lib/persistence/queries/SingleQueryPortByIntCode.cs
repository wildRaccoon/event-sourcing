using ev.lib.domain.app.queries;
using ev.lib.domain.core;
using ev.lib.persistence.entites.domain;
using ev.lib.persistence.services.DataRepository;
using System;
using System.Threading.Tasks;

namespace ev.lib.persistence.queries
{
    public class SingleQueryPortByIntCode : ISingleQueryPortByIntCode
    {
        string intCode;
        IDataRepository<Port, PortData> dataRepository;

        public SingleQueryPortByIntCode(IDataRepository<Port, PortData> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public async Task<Port> ExecuteAsync()
        {
            if (string.IsNullOrEmpty(intCode))
            {
                throw new Exception($"IntCode not set.");
            }

            return await dataRepository.QuerySingle(f => f.IntlCode == intCode);
        }

        public ISingleQueryPortByIntCode UseIntCode(string intCode)
        {
            if (!string.IsNullOrEmpty(this.intCode))
            {
                throw new Exception($"IntCode value already setted up.");
            }

            this.intCode = intCode;

            return this;
        }
    }
}
