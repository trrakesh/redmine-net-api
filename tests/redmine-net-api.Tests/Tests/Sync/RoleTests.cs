﻿/*
   Copyright 2011 - 2023 Adrian Popescu

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using Padi.RedmineApi.Tests.Infrastructure;
using Redmine.Net.Api.Types;
using Xunit;

namespace Padi.RedmineApi.Tests.Tests.Sync
{
	[Trait("Redmine-Net-Api", "Roles")]
#if !(NET20 || NET40)
    [Collection("RedmineCollection")]
#endif
    public class RoleTests
    {
        public RoleTests(RedmineFixture fixture)
        {
            this.fixture = fixture;
        }

        private readonly RedmineFixture fixture;

        [Fact, Order(1)]
        public void Should_Get_All_Roles()
        {
            const int NUMBER_OF_ROLES = 3;
            var roles = fixture.RedmineManager.GetObjects<Role>();

            Assert.NotNull(roles);
            Assert.True(roles.Count == NUMBER_OF_ROLES, "Roles count(" + roles.Count + ") != " + NUMBER_OF_ROLES);
        }

        [Fact, Order(2)]
        public void Should_Get_Role_By_Id()
        {
            const string ROLE_ID = "5";
            const int NUMBER_OF_ROLE_PERMISSIONS = 1;
            const string ROLE_NAME = "CustomRole";

            var role = fixture.RedmineManager.GetObject<Role>(ROLE_ID, null);

            Assert.NotNull(role);
            Assert.True(role.Name.Equals(ROLE_NAME), "Role name is invalid.");

            Assert.NotNull(role.Permissions);
            Assert.True(role.Permissions.Count == NUMBER_OF_ROLE_PERMISSIONS,
                "Permissions count(" + role.Permissions.Count + ") != " + NUMBER_OF_ROLE_PERMISSIONS);
        }
    }
}