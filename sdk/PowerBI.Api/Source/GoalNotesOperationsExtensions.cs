// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for GoalNotesOperations.
    /// </summary>
    public static partial class GoalNotesOperationsExtensions
    {
            /// <summary>
            /// Adds a new note to a goal value check-in.
            /// </summary>
            /// <remarks>
            ///
            /// ## Required scope
            ///
            /// Dataset.ReadWrite.All
            ///
            /// ##
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='goalNote'>
            /// The goal check-in note.
            /// </param>
            public static GoalNote Post(this IGoalNotesOperations operations, GoalNoteRequest goalNote)
            {
                return operations.PostAsync(goalNote).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Adds a new note to a goal value check-in.
            /// </summary>
            /// <remarks>
            ///
            /// ## Required scope
            ///
            /// Dataset.ReadWrite.All
            ///
            /// ##
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='goalNote'>
            /// The goal check-in note.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GoalNote> PostAsync(this IGoalNotesOperations operations, GoalNoteRequest goalNote, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostWithHttpMessagesAsync(goalNote, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates a goal value check-in note by ID.
            /// </summary>
            /// <remarks>
            ///
            /// ## Required scope
            ///
            /// Dataset.ReadWrite.All
            ///
            /// ##
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='goalNote'>
            /// The note content to be updated.
            /// </param>
            public static GoalNote PatchById(this IGoalNotesOperations operations, GoalNoteRequest goalNote)
            {
                return operations.PatchByIdAsync(goalNote).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates a goal value check-in note by ID.
            /// </summary>
            /// <remarks>
            ///
            /// ## Required scope
            ///
            /// Dataset.ReadWrite.All
            ///
            /// ##
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='goalNote'>
            /// The note content to be updated.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GoalNote> PatchByIdAsync(this IGoalNotesOperations operations, GoalNoteRequest goalNote, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PatchByIdWithHttpMessagesAsync(goalNote, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a goal value check-in note by ID.
            /// </summary>
            /// <remarks>
            ///
            /// ## Required scope
            ///
            /// Dataset.ReadWrite.All
            ///
            /// ##
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void DeleteById(this IGoalNotesOperations operations)
            {
                operations.DeleteByIdAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a goal value check-in note by ID.
            /// </summary>
            /// <remarks>
            ///
            /// ## Required scope
            ///
            /// Dataset.ReadWrite.All
            ///
            /// ##
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteByIdAsync(this IGoalNotesOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteByIdWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
