using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SemanticKernalApplication.Core.Models
{
  public class DocumentAttachment
  {
    [Required]
    [JsonPropertyName("fileName")]
    public string FileName { get; set; }

    [JsonPropertyName("fileContent")]
    public byte[] FileContent { get; set; }

    //[Required]
    [JsonPropertyName("fileContentType")]
    public string FileContentType { get; set; }

    [JsonPropertyName("fileUrl")]
    public string FileUrl { get; set; }
  }

  public class DocumentAttachments
  {
    [Required]
    [JsonPropertyName("attachments")]
    public List<DocumentAttachment> Attachments { get; set; }

    [JsonPropertyName("folderName")]
    public string FolderName { get; set; }  // = Folder name where we would like to upload the file. Prefer to have a unique name like UUID        

    [JsonPropertyName("allowedFileSize")]
    public int AllowedFileSize { get; set; }
  }

  public class FileUploadResponseModel
  {
    [JsonPropertyName("fileUrl")]
    public string FileUrl { get; set; }

    [JsonPropertyName("fileName")]
    public string FileName { get; set; }
  }

  public class IHDocuments
  {
    [JsonPropertyName("comments")]
    public string Comments { get; set; }

    [JsonPropertyName("name")]
    public string FieldName { get; set; }

    [JsonPropertyName("Attachments")]
    public List<DocumentAttachment> Attachments { get; set; }
  }
}