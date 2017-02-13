//----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------

namespace Microsoft.PowerBI.Security
{
    /// <summary>
    /// The Power BI app token permission scopes definitions used with Power BI Embedded services
    /// </summary>
    public static class Scopes
    {
        /// <summary>
        /// Dataset Read permission
        /// </summary>
        public const string DatasetRead = "Dataset.Read";

        /// <summary>
        /// Dataset Write permission
        /// </summary>
        public const string DatasetWrite = "Dataset.Write";

        /// <summary>
        /// Dataset Read & Write permission
        /// </summary>
        public const string DatasetReadWrite = "Dataset.ReadWrite";

        /// <summary>
        /// Report Read (View) permission
        /// </summary>
        public const string ReportRead = "Report.Read";

        /// <summary>
        /// Report Read & Write (View & Edit) permission
        /// </summary>
        public const string ReportReadWrite = "Report.ReadWrite";

        /// <summary>
        /// Create new Report in Workspace permission
        /// </summary>
        public const string WorkspaceCreateReport = "Workspace.Report.Create";

        /// <summary>
        /// Copy existing Report in Workspace permission
        /// </summary>
        public const string WorkspaceCopyReport = "Workspace.Report.Copy";
    }
}
