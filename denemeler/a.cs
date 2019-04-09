class a
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>();
        modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });
        modelBuilder.Entity<Post>().HasMany(p => p.Tags).WithOne(t => t.Post).OnDelete(DeleteBehavior.Cascade).IsRequired();
        modelBuilder.Entity<Tag>().HasMany(t => t.Tags).WithOne(p => p.Tag).OnDelete(DeleteBehavior.Cascade).IsRequired(); 
        base.OnModelCreating(modelBuilder);
    }
}
 