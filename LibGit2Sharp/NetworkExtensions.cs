using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LibGit2Sharp.Core;

namespace LibGit2Sharp
{
    /// <summary>
    /// Provides helper overloads to a <see cref="Network"/>.
    /// </summary>
    public static class NetworkExtensions
    {
        /// <summary>
        /// List references in a <see cref="Remote"/> repository.
        /// <para>
        /// When the remote tips are ahead of the local ones, the retrieved
        /// <see cref="DirectReference"/>s may point to non existing
        /// <see cref="GitObject"/>s in the local repository. In that
        /// case, <see cref="DirectReference.Target"/> will return <c>null</c>.
        /// </para>
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The <see cref="Remote"/> to list from.</param>
        /// <returns>The references in the <see cref="Remote"/> repository.</returns>
        public static IEnumerable<DirectReference> ListReferences(this Network network, Remote remote)
        {
            return network.ListReferences(remote, null);
        }

        /// <summary>
        /// List references in a remote repository.
        /// <para>
        /// When the remote tips are ahead of the local ones, the retrieved
        /// <see cref="DirectReference"/>s may point to non existing
        /// <see cref="GitObject"/>s in the local repository. In that
        /// case, <see cref="DirectReference.Target"/> will return <c>null</c>.
        /// </para>
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="url">The url to list from.</param>
        /// <returns>The references in the remote repository.</returns>
        public static IEnumerable<DirectReference> ListReferences(this Network network, string url)
        {
            return network.ListReferences(url, null);
        }


        /// <summary>
        /// Fetch from the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The remote to fetch</param>
        public static void Fetch(this Network network, Remote remote)
        {
            network.Fetch(remote, null, null);
        }

        /// <summary>
        /// Fetch from the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The remote to fetch</param>
        /// <param name="options"><see cref="FetchOptions"/> controlling fetch behavior</param>
        public static void Fetch(this Network network, Remote remote, FetchOptions options)
        {
            network.Fetch(remote, options, null);
        }

        /// <summary>
        /// Fetch from the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The remote to fetch</param>
        /// <param name="logMessage">Message to use when updating the reflog.</param>
        public static void Fetch(this Network network, Remote remote, string logMessage)
        {
            network.Fetch(remote, null, logMessage);
        }

        /// <summary>
        /// Fetch from the <see cref="Remote"/>, using custom refspecs.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The remote to fetch</param>
        /// <param name="refspecs">Refspecs to use, replacing the remote's fetch refspecs</param>
        public static void Fetch(this Network network, Remote remote, IEnumerable<string> refspecs)
        {
            network.Fetch(remote, refspecs, null, null);
        }

        /// <summary>
        /// Fetch from the <see cref="Remote"/>, using custom refspecs.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The remote to fetch</param>
        /// <param name="refspecs">Refspecs to use, replacing the remote's fetch refspecs</param>
        /// <param name="options"><see cref="FetchOptions"/> controlling fetch behavior</param>
        public static void Fetch(this Network network, Remote remote, IEnumerable<string> refspecs, FetchOptions options)
        {
            network.Fetch(remote, refspecs, options, null);
        }

        /// <summary>
        /// Fetch from the <see cref="Remote"/>, using custom refspecs.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The remote to fetch</param>
        /// <param name="refspecs">Refspecs to use, replacing the remote's fetch refspecs</param>
        /// <param name="logMessage">Message to use when updating the reflog.</param>
        public static void Fetch(this Network network, Remote remote, IEnumerable<string> refspecs, string logMessage)
        {
            network.Fetch(remote, refspecs, null, logMessage);
        }

        /// <summary>
        /// Fetch from a url with a set of fetch refspecs
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="url">The url to fetch from</param>
        /// <param name="refspecs">The list of resfpecs to use</param>
        public static void Fetch(
            this Network network,
            string url,
            IEnumerable<string> refspecs)
        {
            network.Fetch(url, refspecs, null, null);
        }

        /// <summary>
        /// Fetch from a url with a set of fetch refspecs
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="url">The url to fetch from</param>
        /// <param name="refspecs">The list of resfpecs to use</param>
        /// <param name="options"><see cref="FetchOptions"/> controlling fetch behavior</param>
        public static void Fetch(
            this Network network,
            string url,
            IEnumerable<string> refspecs,
            FetchOptions options)
        {
            network.Fetch(url, refspecs, options, null);
        }

        /// <summary>
        /// Fetch from a url with a set of fetch refspecs
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="url">The url to fetch from</param>
        /// <param name="refspecs">The list of resfpecs to use</param>
        /// <param name="logMessage">Message to use when updating the reflog.</param>
        public static void Fetch(
            this Network network,
            string url,
            IEnumerable<string> refspecs,
            string logMessage)
        {
            network.Fetch(url, refspecs, null, logMessage);
        }

        /// <summary>
        /// Push the specified branch to its tracked branch on the remote.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="branch">The branch to push.</param>
        /// <exception cref="LibGit2SharpException">Throws if either the Remote or the UpstreamBranchCanonicalName is not set.</exception>
        public static void Push(
            this Network network,
            Branch branch)
        {
            network.Push(new[] { branch });
        }
        /// <summary>
        /// Push the specified branch to its tracked branch on the remote.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="branch">The branch to push.</param>
        /// <param name="pushOptions"><see cref="PushOptions"/> controlling push behavior</param>
        /// <exception cref="LibGit2SharpException">Throws if either the Remote or the UpstreamBranchCanonicalName is not set.</exception>
        public static void Push(
            this Network network,
            Branch branch,
            PushOptions pushOptions)
        {
            network.Push(new[] { branch }, pushOptions);
        }

        /// <summary>
        /// Push the specified branches to their tracked branches on the remote.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="branches">The branches to push.</param>
        /// <exception cref="LibGit2SharpException">Throws if either the Remote or the UpstreamBranchCanonicalName is not set.</exception>
        public static void Push(
            this Network network,
            IEnumerable<Branch> branches)
        {
            network.Push(branches, null);
        }

        /// <summary>
        /// Push the specified branches to their tracked branches on the remote.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="branches">The branches to push.</param>
        /// <param name="pushOptions"><see cref="PushOptions"/> controlling push behavior</param>
        /// <exception cref="LibGit2SharpException">Throws if either the Remote or the UpstreamBranchCanonicalName is not set.</exception>
        public static void Push(
            this Network network,
            IEnumerable<Branch> branches,
            PushOptions pushOptions)
        {
            var enumeratedBranches = branches as IList<Branch> ?? branches.ToList();

            foreach (var branch in enumeratedBranches)
            {
                if (string.IsNullOrEmpty(branch.UpstreamBranchCanonicalName))
                {
                    throw new LibGit2SharpException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "The branch '{0}' (\"{1}\") that you are trying to push does not track an upstream branch.",
                            branch.FriendlyName, branch.CanonicalName));
                }
            }

            foreach (var branch in enumeratedBranches)
            {
                network.Push(branch.Remote, string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}:{1}", branch.CanonicalName, branch.UpstreamBranchCanonicalName), pushOptions);
            }
        }

        /// <summary>
        /// Push specified reference to the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The <see cref="Remote"/> to push to.</param>
        /// <param name="pushRefSpec">The pushRefSpec to push.</param>
        public static void Push(
            this Network network,
            Remote remote,
            string pushRefSpec)
        {
            Ensure.ArgumentNotNullOrEmptyString(pushRefSpec, "pushRefSpec");

            network.Push(remote, new[] { pushRefSpec });
        }
        /// <summary>
        /// Push specified reference to the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The <see cref="Remote"/> to push to.</param>
        /// <param name="pushRefSpec">The pushRefSpec to push.</param>
        /// <param name="pushOptions"><see cref="PushOptions"/> controlling push behavior</param>
        public static void Push(
            this Network network,
            Remote remote,
            string pushRefSpec,
            PushOptions pushOptions)
        {
            Ensure.ArgumentNotNullOrEmptyString(pushRefSpec, "pushRefSpec");

            network.Push(remote, new[] { pushRefSpec }, pushOptions);
        }

        /// <summary>
        /// Push specified references to the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The <see cref="Remote"/> to push to.</param>
        /// <param name="pushRefSpecs">The pushRefSpecs to push.</param>
        public static void Push(
            this Network network,
            Remote remote,
            IEnumerable<string> pushRefSpecs)
        {
            network.Push(remote, pushRefSpecs, null);
        }

        /// <summary>
        /// Push the objectish to the destination reference on the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The <see cref="Remote"/> to push to.</param>
        /// <param name="objectish">The source objectish to push.</param>
        /// <param name="destinationSpec">The reference to update on the remote.</param>
        public static void Push(
            this Network network,
            Remote remote,
            string objectish,
            string destinationSpec)
        {
            Ensure.ArgumentNotNull(objectish, "objectish");
            Ensure.ArgumentNotNullOrEmptyString(destinationSpec, "destinationSpec");

            network.Push(remote, string.Format(CultureInfo.InvariantCulture,
                "{0}:{1}", objectish, destinationSpec));
        }

        /// <summary>
        /// Push the objectish to the destination reference on the <see cref="Remote"/>.
        /// </summary>
        /// <param name="network">The <see cref="Network"/> being worked with.</param>
        /// <param name="remote">The <see cref="Remote"/> to push to.</param>
        /// <param name="objectish">The source objectish to push.</param>
        /// <param name="destinationSpec">The reference to update on the remote.</param>
        /// <param name="pushOptions"><see cref="PushOptions"/> controlling push behavior</param>
        public static void Push(
            this Network network,
            Remote remote,
            string objectish,
            string destinationSpec,
            PushOptions pushOptions)
        {
            Ensure.ArgumentNotNull(objectish, "objectish");
            Ensure.ArgumentNotNullOrEmptyString(destinationSpec, "destinationSpec");

            network.Push(remote, string.Format(CultureInfo.InvariantCulture,
                "{0}:{1}", objectish, destinationSpec), pushOptions);
        }
    }
}
