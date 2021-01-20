using Application.Responses.Command;

namespace Application.Features.DataBases.Commands
{
    public class CreateDataBesesCommandResponse : BaseResponseCommand
    {
        public CreateDataBesesCommandResponse() : base()
        {

        }
        public CreateDataBaseDto createDataBaseDto { get; set; }
    }
}
