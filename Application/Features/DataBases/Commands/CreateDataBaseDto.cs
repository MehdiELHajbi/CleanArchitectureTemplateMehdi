﻿namespace Application.Features.DataBases.Commands
{
    public class CreateDataBaseDto
    {
        public int idDataBase { get; set; }
        public string NameDataBase { get; set; }
        public string ConnetionName { get; set; }
        public string TypeDataBase { get; set; }


    }
}
