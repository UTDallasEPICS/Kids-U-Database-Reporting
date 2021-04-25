using Kids_U_Database_Reporting.Data;
using Kids_U_Database_Reporting.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kids_U_Database_Reporting.Services
{
    public class OrganizationsService : IOrganizationsService
    {
        private readonly ApplicationDbContext _context;

        public OrganizationsService(ApplicationDbContext context)
        {
            //new instance of service is made during each request (required for talking to database) aka scoped lifecycle
            _context = context;
        }

        // Get all Organizations from the database. Returned in alphabetical order
        public async Task<Organization[]> GetOrganizationsAsync()
        {
            return await _context.Organizations
                .OrderBy(x => x.OrganizationName)
                .ToArrayAsync();
        }

        public async Task<Organization> GetOrganization(int organizationId)
        {
            return await _context.Organizations
                .Where(x => x.OrganizationId == organizationId)
                .FirstAsync();
        }

        public async Task<bool> DeleteOrganizationAsync(int organizationId)
        {
            Organization deleteOrganization = await _context.Organizations
                .Where(x => x.OrganizationId == organizationId)
                .FirstAsync();

            _context.Organizations.Remove(deleteOrganization);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> AddOrganizationAsync(Organization newOrganization)
        {
            _context.Organizations.Add(newOrganization);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> ApplyEditOrganizationAsync(Organization editedOrganization)
        {
            _context.Entry(await _context.Organizations.FirstAsync(x => x.OrganizationId == editedOrganization.OrganizationId)).CurrentValues.SetValues(editedOrganization);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}

