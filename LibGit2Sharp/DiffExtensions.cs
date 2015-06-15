using System.Collections.Generic;

namespace LibGit2Sharp
{
    /// <summary>
    /// Provides helper overloads to a <see cref="Diff"/>.
    /// </summary>
    public static class DiffExtensions
    {
        /// <summary>
        /// Show changes between two <see cref="Blob"/>s.
        /// </summary>
        /// <param name="oldBlob">The <see cref="Blob"/> you want to compare from.</param>
        /// <param name="newBlob">The <see cref="Blob"/> you want to compare to.</param>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <see cref="ContentChanges"/> containing the changes between the <paramref name="oldBlob"/> and the <paramref name="newBlob"/>.</returns>
        public static ContentChanges Compare(this Diff diff, Blob oldBlob, Blob newBlob)
        {
            return diff.Compare(oldBlob, newBlob, null);
        }

        /// <summary>
        /// Show changes between two <see cref="Tree"/>s.
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> you want to compare from.</param>
        /// <param name="newTree">The <see cref="Tree"/> you want to compare to.</param>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <see cref="TreeChanges"/> containing the changes between the <paramref name="oldTree"/> and the <paramref name="newTree"/>.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, Tree newTree) where T : class
        {
            return diff.Compare<T>(oldTree, newTree, null, null, null);
        }

        /// <summary>
        /// Show changes between two <see cref="Tree"/>s.
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> you want to compare from.</param>
        /// <param name="newTree">The <see cref="Tree"/> you want to compare to.</param>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <see cref="TreeChanges"/> containing the changes between the <paramref name="oldTree"/> and the <paramref name="newTree"/>.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, Tree newTree, IEnumerable<string> paths) where T : class
        {
            return diff.Compare<T>(oldTree, newTree, paths, null, null);
        }

        /// <summary>
        /// Show changes between two <see cref="Tree"/>s.
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> you want to compare from.</param>
        /// <param name="newTree">The <see cref="Tree"/> you want to compare to.</param>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <param name="explicitPathsOptions">
        /// If set, the passed <paramref name="paths"/> will be treated as explicit paths.
        /// Use these options to determine how unmatched explicit paths should be handled.
        /// </param>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <see cref="TreeChanges"/> containing the changes between the <paramref name="oldTree"/> and the <paramref name="newTree"/>.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, Tree newTree, IEnumerable<string> paths,
            ExplicitPathsOptions explicitPathsOptions) where T : class
        {
            return diff.Compare<T>(oldTree, newTree, paths, explicitPathsOptions, null);
        }

        /// <summary>
        /// Show changes between two <see cref="Tree"/>s.
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> you want to compare from.</param>
        /// <param name="newTree">The <see cref="Tree"/> you want to compare to.</param>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <param name="compareOptions">Additional options to define patch generation behavior.</param>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <see cref="TreeChanges"/> containing the changes between the <paramref name="oldTree"/> and the <paramref name="newTree"/>.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, Tree newTree, IEnumerable<string> paths, CompareOptions compareOptions) where T : class
        {
            return diff.Compare<T>(oldTree, newTree, paths, null, compareOptions);
        }

        /// <summary>
        /// Show changes between two <see cref="Tree"/>s.
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> you want to compare from.</param>
        /// <param name="newTree">The <see cref="Tree"/> you want to compare to.</param>
        /// <param name="compareOptions">Additional options to define patch generation behavior.</param>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <see cref="TreeChanges"/> containing the changes between the <paramref name="oldTree"/> and the <paramref name="newTree"/>.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, Tree newTree, CompareOptions compareOptions) where T : class
        {
            return diff.Compare<T>(oldTree, newTree, null, null, compareOptions);
        }

        /// <summary>
        /// Show changes between a <see cref="Tree"/> and the Index, the Working Directory, or both.
        /// <para>
        /// The level of diff performed can be specified by passing either a <see cref="TreeChanges"/>
        /// or <see cref="Patch"/> type as the generic parameter.
        /// </para>
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> to compare from.</param>
        /// <param name="diffTargets">The targets to compare to.</param>
        /// <typeparam name="T">Can be either a <see cref="TreeChanges"/> if you are only interested in the list of files modified, added, ..., or
        /// a <see cref="Patch"/> if you want the actual patch content for the whole diff and for individual files.</typeparam>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <typeparamref name="T"/> containing the changes between the <see cref="Tree"/> and the selected target.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, DiffTargets diffTargets) where T : class
        {
            return diff.Compare<T>(oldTree, diffTargets, null, null, null);
        }

        /// <summary>
        /// Show changes between a <see cref="Tree"/> and the Index, the Working Directory, or both.
        /// <para>
        /// The level of diff performed can be specified by passing either a <see cref="TreeChanges"/>
        /// or <see cref="Patch"/> type as the generic parameter.
        /// </para>
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> to compare from.</param>
        /// <param name="diffTargets">The targets to compare to.</param>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <typeparam name="T">Can be either a <see cref="TreeChanges"/> if you are only interested in the list of files modified, added, ..., or
        /// a <see cref="Patch"/> if you want the actual patch content for the whole diff and for individual files.</typeparam>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <typeparamref name="T"/> containing the changes between the <see cref="Tree"/> and the selected target.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, DiffTargets diffTargets, IEnumerable<string> paths) where T : class
        {
            return diff.Compare<T>(oldTree, diffTargets, paths, null, null);
        }

        /// <summary>
        /// Show changes between a <see cref="Tree"/> and the Index, the Working Directory, or both.
        /// <para>
        /// The level of diff performed can be specified by passing either a <see cref="TreeChanges"/>
        /// or <see cref="Patch"/> type as the generic parameter.
        /// </para>
        /// </summary>
        /// <param name="oldTree">The <see cref="Tree"/> to compare from.</param>
        /// <param name="diffTargets">The targets to compare to.</param>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <param name="explicitPathsOptions">
        /// If set, the passed <paramref name="paths"/> will be treated as explicit paths.
        /// Use these options to determine how unmatched explicit paths should be handled.
        /// </param>
        /// <typeparam name="T">Can be either a <see cref="TreeChanges"/> if you are only interested in the list of files modified, added, ..., or
        /// a <see cref="Patch"/> if you want the actual patch content for the whole diff and for individual files.</typeparam>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <typeparamref name="T"/> containing the changes between the <see cref="Tree"/> and the selected target.</returns>
        public static T Compare<T>(this Diff diff, Tree oldTree, DiffTargets diffTargets, IEnumerable<string> paths,
            ExplicitPathsOptions explicitPathsOptions) where T : class
        {
            return diff.Compare<T>(oldTree, diffTargets, paths, explicitPathsOptions, null);
        }

        /// <summary>
        /// Show changes between the working directory and the index.
        /// <para>
        /// The level of diff performed can be specified by passing either a <see cref="TreeChanges"/>
        /// or <see cref="Patch"/> type as the generic parameter.
        /// </para>
        /// </summary>
        /// <typeparam name="T">Can be either a <see cref="TreeChanges"/> if you are only interested in the list of files modified, added, ..., or
        /// a <see cref="Patch"/> if you want the actual patch content for the whole diff and for individual files.</typeparam>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <typeparamref name="T"/> containing the changes between the working directory and the index.</returns>
        public static T Compare<T>(this Diff diff) where T : class
        {
            return diff.Compare<T>(null);
        }

        /// <summary>
        /// Show changes between the working directory and the index.
        /// <para>
        /// The level of diff performed can be specified by passing either a <see cref="TreeChanges"/>
        /// or <see cref="Patch"/> type as the generic parameter.
        /// </para>
        /// </summary>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <typeparam name="T">Can be either a <see cref="TreeChanges"/> if you are only interested in the list of files modified, added, ..., or
        /// a <see cref="Patch"/> if you want the actual patch content for the whole diff and for individual files.</typeparam>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <typeparamref name="T"/> containing the changes between the working directory and the index.</returns>
        public static T Compare<T>(this Diff diff, IEnumerable<string> paths) where T : class
        {
            return diff.Compare<T>(paths, false);
        }

        /// <summary>
        /// Show changes between the working directory and the index.
        /// <para>
        /// The level of diff performed can be specified by passing either a <see cref="TreeChanges"/>
        /// or <see cref="Patch"/> type as the generic parameter.
        /// </para>
        /// </summary>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <param name="includeUntracked">If true, include untracked files from the working dir as additions. Otherwise ignore them.</param>
        /// <typeparam name="T">Can be either a <see cref="TreeChanges"/> if you are only interested in the list of files modified, added, ..., or
        /// a <see cref="Patch"/> if you want the actual patch content for the whole diff and for individual files.</typeparam>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <typeparamref name="T"/> containing the changes between the working directory and the index.</returns>
        public static T Compare<T>(this Diff diff, IEnumerable<string> paths, bool includeUntracked) where T : class
        {
            return diff.Compare<T>(paths, includeUntracked, null);
        }

        /// <summary>
        /// Show changes between the working directory and the index.
        /// <para>
        /// The level of diff performed can be specified by passing either a <see cref="TreeChanges"/>
        /// or <see cref="Patch"/> type as the generic parameter.
        /// </para>
        /// </summary>
        /// <param name="paths">The list of paths (either files or directories) that should be compared.</param>
        /// <param name="includeUntracked">If true, include untracked files from the working dir as additions. Otherwise ignore them.</param>
        /// <param name="explicitPathsOptions">
        /// If set, the passed <paramref name="paths"/> will be treated as explicit paths.
        /// Use these options to determine how unmatched explicit paths should be handled.
        /// </param>
        /// <typeparam name="T">Can be either a <see cref="TreeChanges"/> if you are only interested in the list of files modified, added, ..., or
        /// a <see cref="Patch"/> if you want the actual patch content for the whole diff and for individual files.</typeparam>
        /// <param name="diff">The <see cref="Diff"/> being worked with.</param>
        /// <returns>A <typeparamref name="T"/> containing the changes between the working directory and the index.</returns>
        public static T Compare<T>(this Diff diff, IEnumerable<string> paths, bool includeUntracked,
            ExplicitPathsOptions explicitPathsOptions) where T : class
        {
            return diff.Compare<T>(paths, includeUntracked, explicitPathsOptions, null);
        }
    }
}
