using System;
using System.Collections.Generic;

namespace BE.Dto.Permisson;

public  class CreatePermissonDto
{

    public string? RoleId { get; set; }

    public string? ResourcesId { get; set; }

    public string? LastEditor { get; set; }

    public bool? Request { get; set; }

    public bool? Create { get; set; }

    public bool? Delete { get; set; }

    public bool? Update { get; set; }

    public bool? View { get; set; }

}
