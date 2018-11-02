﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CSAA.ServiceModels;
using System.Net.Http;

namespace Client.Requests
{
    public class ProjectRequest : Request, IProjectRequest
    {
        #region Constructor

        public ProjectRequest(IHttpClient client) : base(client)
        {

        }

        #endregion

        #region Public Methods

        public List<Project> GetProjects()
        {
            return GetProjectsAsync().GetAwaiter().GetResult();
        }

        public Project GetProjectById(string projectId)
        {
            return GetProjectByIdAsync(projectId).GetAwaiter().GetResult();
        }

        public string CreateProject(Project project)
        {
            return CreateProjectAsync(project).GetAwaiter().GetResult();
        }

        public bool UpdateProject(string projectId, Project project)
        {
            return UpdateProjectAsync(projectId, project).GetAwaiter().GetResult();
        }

        public bool DeleteProject(string projectId)
        {
            return DeleteProjectAsync(projectId).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        private async Task<List<Project>> GetProjectsAsync()
        {
            var response = await client.GetAsync("api/Project").ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<List<Project>>().ConfigureAwait(false);
        }

        private async Task<Project> GetProjectByIdAsync(string projectId)
        {
            var response = await client.GetAsync("api/Project/" + projectId).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<Project>().ConfigureAwait(false);
        }

        private async Task<string> CreateProjectAsync(Project project)
        {
            var response = await client.PostAsJsonAsync("api/Project", project).ConfigureAwait(false);
            var result = await CheckResponse(response).ConfigureAwait(false);
            var projectId = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return projectId.Substring(1, projectId.Length - 2);
        }

        private async Task<bool> UpdateProjectAsync(string projectId, Project project)
        {
            var response = await client.PutAsJsonAsync("api/Project/" + projectId, project).ConfigureAwait(false);
            return await CheckResponse(response).ConfigureAwait(false);
        }

        private async Task<bool> DeleteProjectAsync(string projectId)
        {
            var response = await client.DeleteAsync("api/Project/" + projectId).ConfigureAwait(false);
            return await CheckResponse(response).ConfigureAwait(false);
        }

        #endregion
    }
}
