using System;
using System.Threading.Tasks;

namespace FashFans.ViewModels.Base {
    public interface IVisualFiguring {

        string TabHeader { get; }

        Type RelativeViewType { get; }

        void Dispose();

        Task InitializeAsync(object navigationData);
    }
}
