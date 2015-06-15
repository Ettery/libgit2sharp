namespace LibGit2Sharp
{
    /// <summary>
    /// Commit metadata when rewriting history
    /// </summary>
    public sealed partial class CommitRewriteInfo
    {
        /// <summary>
        /// The author to be used for the new commit
        /// </summary>
        public Signature Author { get; set; }

        /// <summary>
        /// The committer to be used for the new commit
        /// </summary>
        public Signature Committer { get; set; }

        /// <summary>
        /// The message to be used for the new commit
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Build a <see cref="CommitRewriteInfo"/> from the <see cref="Commit"/> passed in
        /// </summary>
        /// <param name="commit">The <see cref="Commit"/> whose information is to be copied</param>
        /// <returns>A new <see cref="CommitRewriteInfo"/> object that matches the info for the <paramref name="commit"/>.</returns>
        public static CommitRewriteInfo From(Commit commit)
        {
            return new CommitRewriteInfo
                {
                    Author = commit.Author,
                    Committer = commit.Committer,
                    Message = commit.Message
                };
        }
    }
}
