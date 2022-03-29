using ConsoleApp3;

var listEntity = new List<Entity>()
{
    new Entity() { Id = 1, ParentId = 0, Name = "Root entity"},
    new Entity() { Id = 2, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() { Id = 3, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() { Id = 4, ParentId = 2, Name = "Child of 2 entity"},
    new Entity() { Id = 5, ParentId = 4, Name = "Child of 4 entity"}
};

Dictionary<int, List<Entity>> ListToDictionary(List<Entity> entities)
{
    var dictionary = new Dictionary<int, List<Entity>>();
    foreach(var entity in entities)
    {
        if (!dictionary.ContainsKey(entity.ParentId))
            dictionary.Add(entity.ParentId, new List<Entity>() { entity });
        else dictionary[entity.ParentId].Add(entity);
    }
    return dictionary;
}

var dictionary = new Dictionary<int, List<Entity>>(ListToDictionary(listEntity));
