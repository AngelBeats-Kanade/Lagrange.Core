using System.Text.Json;
using System.Text.Json.Nodes;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Message.Entity;
using Lagrange.OneBot.Core.Entity.Action;
using Lagrange.OneBot.Core.Operation.Converters;

namespace Lagrange.OneBot.Core.Operation.Message;

[Operation("upload_group_file")]
public class UploadGroupFileOperation : IOperation
{
    public async Task<OneBotResult> HandleOperation(BotContext context, JsonNode? payload)
    {
        if (payload.Deserialize<OneBotUploadGroupFile>(SerializerOptions.DefaultOptions) is { } file)
        {
            var entity = new FileEntity(file.File);
            if (file.Name != null) entity.FileName = file.Name;

            bool result = await context.GroupFSUpload(file.GroupId, entity, file.Folder ?? "/");
            return new OneBotResult(null, result ? 0 : 1, result ? "ok" : "failed");
        }
        
        throw new Exception();
    }
}