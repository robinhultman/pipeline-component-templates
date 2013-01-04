using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using IComponent = Microsoft.BizTalk.Component.Interop.IComponent;

namespace $safeprojectname$
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("$guid1$")]
    [ComponentCategory(CategoryTypes.CATID_Receiver)]
    public class $safeitemname$ : IComponent, IBaseComponent,
                                        IPersistPropertyBag, IComponentUI
    {
        private readonly ResourceManager _resourceManager =
         new ResourceManager("$safeprojectname$.PipelineResources",
             Assembly.GetExecutingAssembly());
		#region Implementation of IComponent
        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            throw new NotImplementedException();
        }
		#endregion 
		
		#region Implementation of IBaseComponent
        [Browsable(false)]
        public string Name
        {
            get { return _resourceManager.GetString("COMPONENTNAME", System.Globalization.CultureInfo.InvariantCulture); }
        }

        [Browsable(false)]
        public string Version
        {
            get { return _resourceManager.GetString("COMPONENTVERSION", System.Globalization.CultureInfo.InvariantCulture); }
        }

        [Browsable(false)]
        public string Description
        {
            get
            {
                return _resourceManager.GetString("COMPONENTDESCRIPTION",
                                                 System.Globalization.CultureInfo.InvariantCulture);
            }
        }
		#endregion
		
		#region Implementation of IPersistPropertyBag
        public void GetClassID(out Guid classID)
        {
            classID = new Guid("$guid2$");
        }

        public void InitNew()
        {
            throw new NotImplementedException();
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            throw new NotImplementedException();
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerator Validate(object projectSystem)
        {
            throw new NotImplementedException();
        }

        public IntPtr Icon { get; private set; }
		#endregion
          #region Utility Functionality

        private static string ToStringOrDefault(object property, string defaultValue)
        {
            if (property != null)
            {
                return property.ToString();
            }
            
            return defaultValue;
        }

        /// <summary>
        /// Reads property value from property bag
        /// </summary>
        /// <param name="pb">Property bag</param>
        /// <param name="propName">Name of property</param>
        /// <returns>Value of the property</returns>
        private object ReadPropertyBag(IPropertyBag pb, string propName)
        {
            object val = null;
            try
            {
                pb.Read(propName, out val, 0);
            }
            catch (ArgumentException)
            {
                return val;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return val;
        }

        /// <summary>
        /// Writes property values into a property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <param name="val">Value of property.</param>
        private void WritePropertyBag(IPropertyBag pb, string propName, object val)
        {
            try
            {
                pb.Write(propName, ref val);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
        #endregion
    }
}
