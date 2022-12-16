using LobInkInterview.DataAccess;
using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Models;
using LobInkInterview.DataAccess.Repositories;
using MongoDB.Driver;
using Moq;
using System.Linq.Expressions;

namespace LobInkInterview.Tests
{
    public class DataAccessTests
    {
        //no easy way to mock mongodb client and no in-memory DB
        //with EFCore I would usually use the SQLLite in-memory DB
        //here only thing we could do is testing against the real thing in the image, not really an unit test
        //will skip for now
    }
}