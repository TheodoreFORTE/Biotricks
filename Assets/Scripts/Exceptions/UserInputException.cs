using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputException : Exception
{
    
    public UserInputException() : base("Invalid input from the user")
    {

    }

    public UserInputException(string message) : base(message)
    {
    
    }



}
