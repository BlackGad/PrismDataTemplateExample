using System;
using System.Collections;
using System.ComponentModel.Composition;

namespace PrismDataTemplateExample.Models
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DataProvider
    {
        private readonly Random _random;
        private IEnumerable _data;

        #region Constructors

        public DataProvider()
        {
            _random = new Random();
        }

        #endregion

        #region Properties

        public IEnumerable Data
        {
            get { return _data ?? (_data = InitializeData()); }
        }

        #endregion

        #region Members

        private IEnumerable InitializeData()
        {
            var groupCount = _random.Next(1, 10);
            for (var i = 0; i < groupCount; i++)
            {
                var group = new DataGroup
                {
                    Title = string.Format("Group {0}", i),
                    Priority = _random.Next(0, 100)
                };

                var itemCountInGroup = _random.Next(1, 10);
                for (int j = 0; j < itemCountInGroup; j++)
                {
                    group.Items.Add(new DataItem()
                    {
                        Name = string.Format("Item {0}", j)
                    });
                }
                yield return group;
            }
        }

        #endregion
    }
}