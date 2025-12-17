using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_QLResort
{
    public class BaseModel 
    {
        private DateTime _createdAt;
        private string _createdBy;
        private DateTime? _updatedAt;
        private string _updatedBy;
        private bool _isActive = true;

        public DateTime CreatedAt 
        { 
            get { return _createdAt; } 
            set { _createdAt = value; } 
        }
        
        public string CreatedBy 
        { 
            get { return _createdBy; } 
            set { _createdBy = value; } 
        }
        
        public DateTime? UpdatedAt 
        { 
            get { return _updatedAt; } 
            set { _updatedAt = value; } 
        }
        
        public string UpdatedBy 
        { 
            get { return _updatedBy; } 
            set { _updatedBy = value; } 
        }
        
        public bool IsActive 
        { 
            get { return _isActive; } 
            set { _isActive = value; } 
        }
    }
}
