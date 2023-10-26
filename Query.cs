using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

public class PsLinqGo : IEnumerable<object>
{
    private readonly IEnumerable<object> _psobjects;

    public PsLinqGo(IEnumerable<object> psobject)
    {
        _psobjects = psobject;
    }

    public IEnumerator<object> GetEnumerator()
    {
        return _psobjects.GetEnumerator();
    }

    public bool All(ScriptBlock scriptBlock)
    {
        return _psobjects.All(x => (bool)scriptBlock.Invoke(x).First().BaseObject == true);
    }

    public bool Any(ScriptBlock scriptBlock)
    {
        return _psobjects.Any(x => (bool)scriptBlock.Invoke(x).First().BaseObject == true);
    }

    public decimal Average(ScriptBlock scriptBlock)
    {
        return _psobjects.Average(x => (decimal)scriptBlock.Invoke(x).First().BaseObject);
    }

    public PsLinqGo Concat(IEnumerable<object> psobjects)
    {
        return new PsLinqGo(_psobjects.Concat(psobjects));
    }

    public bool Contains(object obj)
    {
        return _psobjects.Contains(obj);
    }

    public int Count()
    {
        return _psobjects.Count();
    }

    public PsLinqGo Distinct()
    {
        return new PsLinqGo(_psobjects.Distinct());
    }

    public object ElementAt(int index)
    {
        return _psobjects.ElementAt(index);
    }

    public PsLinqGo Except(IEnumerable<object> psobjects)
    {
        return new PsLinqGo(_psobjects.Except(psobjects));
    }

    public object First()
    {
        return _psobjects.First();
    }

    public object FirstOrDefault()
    {
        return _psobjects.FirstOrDefault();
    }

    public object Last()
    {
        return _psobjects.Last();
    }

    public object LastOrDefault()
    {
        return _psobjects.LastOrDefault();
    }

    public object Single()
    {
        return _psobjects.Single();
    }

    public object SingleOrDefault()
    {
        return _psobjects.SingleOrDefault();
    }

    public PsLinqGo Skip(int count)
    {
        return new PsLinqGo(_psobjects.Skip(count));
    }

    public decimal Sum(ScriptBlock scriptBlock)
    {
        return _psobjects.Sum(x => Convert.ToDecimal(scriptBlock.Invoke(x).First().BaseObject));
    }

    public PsLinqGo Take(int count)
    {
        return new PsLinqGo(_psobjects.Take(count));
    }

    public PsLinqGo Where(ScriptBlock scriptBlock)
    {
        return new PsLinqGo(_psobjects.Where(x => (bool)scriptBlock.Invoke(x).First().BaseObject == true));
    }

    public PsLinqGo Select(ScriptBlock scriptBlock)
    {
        return new PsLinqGo(_psobjects.Select(x => scriptBlock.Invoke(x).First()));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _psobjects.GetEnumerator();
    }
}