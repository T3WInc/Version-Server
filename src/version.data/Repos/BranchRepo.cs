﻿using System;
using System.Linq;
using t3winc.version.common.Interfaces;
using t3winc.version.common.Models;
using t3winc.version.data.Helper;
using t3winc.version.domain;

namespace t3winc.version.data.Repos
{
    public class BranchRepo : IBranchRepo
    {
        private VersionContext _context;

        public BranchRepo(VersionContext context)
        {
            _context = context;
        }

        internal bool BranchExists(int id, string product, string branch)
        {
            ProductRepo repo = new ProductRepo(_context);
            var myProduct = repo.GetProductDomain(id, product);
            return _context.Branch.Any(e => e.Name == branch && e.Product == myProduct);
        }

        internal Branch GetBranch(int version, string product, string branch)
        {
            ProductRepo repo = new ProductRepo(_context);
            var myProduct = repo.GetProductDomain(version, product);
            return _context.Branch.Where(e => e.Name == branch && e.Product == myProduct).FirstOrDefault();
        }

        internal Branch NewBranch(int version, string product, string newbranch)
        {
            var suffix = VersionHelper.GetSuffix(newbranch);
            Branch branch = new Branch();
            switch (suffix)
            {
                case "alpha":
                    branch.Minor++;
                    branch.Patch = 0;
                    branch.Revision = 0;
                    break;
                case "beta":
                    branch.Patch++;
                    branch.Revision = 0;
                    break;
                case "torn":
                    branch.Major++;
                    branch.Minor = 0;
                    branch.Patch = 0;
                    branch.Revision = 0;
                    break;
            }
            branch.Version = $"{branch.Major}.{branch.Minor}.{branch.Patch}-{suffix}.{branch.Revision}";
            branch.Name = newbranch;
            _context.Branch.Add(branch);
            return branch;
        }
    }
}