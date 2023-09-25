using System;
using System.Collections.Generic;

namespace ENTITY;

//ESTA CLASE SE MUEVE DEL DB CONTEXT ANTERIORMENTE CREADO
public partial class Person
{
    //AQUI ESTAN LOS ATRIBUTOS DE LA BASE DE DATOS
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? CPassword { get; set; }

    public string? CName { get; set; }

    public string? CSurname { get; set; }

    public string? Email { get; set; }
}
