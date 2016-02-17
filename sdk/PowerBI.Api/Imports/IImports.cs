using Microsoft.Rest;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.PowerBI.Api.Beta
{
    public partial interface IImports
    {
        Task<HttpOperationResponse<object>> PostImporFileWithHttpMessage(Stream file, string datasetDisplayName, int? nameConflict = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<HttpOperationResponse<object>> PostImporFileByGroupWithHttpMessage(string group, Stream file, string datasetDisplayName, int? nameConflict = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
