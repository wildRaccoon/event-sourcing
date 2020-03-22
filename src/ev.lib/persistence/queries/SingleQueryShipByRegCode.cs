using ev.lib.domain.app.queries;
using ev.lib.domain.core;
using ev.lib.persistence.entites.domain;
using ev.lib.persistence.services.DataRepository;
using System;
using System.Threading.Tasks;

namespace ev.lib.persistence.queries
{
    public class SingleQueryShipByRegCode : ISingleQueryShipByRegCode
    {
        string regCode;
        IDataRepository<Ship, ShipData> dataRepository;

        public SingleQueryShipByRegCode(IDataRepository<Ship, ShipData> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public async Task<Ship> ExecuteAsync()
        {
            if (string.IsNullOrEmpty(this.regCode))
            {
                throw new Exception($"RegCode not set.");
            }

            return await dataRepository.QuerySingle(f => f.RegistrationCode == regCode);
        }

        public ISingleQueryShipByRegCode UseRegCode(string regCode)
        {
            if (!string.IsNullOrEmpty(this.regCode))
            {
                throw new Exception($"RegCode value already setted up.");
            }

            this.regCode = regCode;
            return this;
        }
    }
}
