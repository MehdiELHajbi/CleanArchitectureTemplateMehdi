using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands
{
    public class CreateDataBesesCommandHandler : IRequestHandler<CreateDataBesesCommand, CreateDataBesesCommandResponse>
    {
        private readonly IDataBaseRepository _dataBaseRepository;
        private readonly IMapper _mapper;

        public CreateDataBesesCommandHandler(IMapper mapper, IDataBaseRepository dataBaseRepository)
        {
            _mapper = mapper;
            _dataBaseRepository = dataBaseRepository;
        }
        public async Task<CreateDataBesesCommandResponse> Handle(CreateDataBesesCommand request, CancellationToken cancellationToken)
        {
            var CreateDataBesesCommandResponse = new CreateDataBesesCommandResponse();
            // Validation of Data comming from Request
            var validator = new CreateDataBesesValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                CreateDataBesesCommandResponse.Success = false;
                CreateDataBesesCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    CreateDataBesesCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }


                //throw new ValidationException(validationResult);
            }

            if (CreateDataBesesCommandResponse.Success)
            {
                var dataBase = new DataBase()
                {
                    ConnetionName = request.ConnetionName,
                    NameDataBase = request.NameDataBase,
                    TypeDataBase = request.TypeDataBase
                };
                dataBase = await _dataBaseRepository.AddAsync(dataBase);
                CreateDataBesesCommandResponse.createDataBaseDto = _mapper.Map<CreateDataBaseDto>(dataBase);
            }
            // Map Data
            //var databaseToAdd = _mapper.Map<DataBase>(request);
            // Add DATA
            //var result = await _dataBaseRepository.AddAsync(databaseToAdd);

            //return result.IdDataBase;

            return CreateDataBesesCommandResponse;
        }
    }
}
