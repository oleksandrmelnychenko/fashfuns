using FashFans.Models.Args.SelectedContent;
using FashFans.Models.Identities;
using FashFans.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.BottomTabs.Home {
    public sealed class DesignersContentViewModel : NestedViewModel {

        ObservableCollection<Designer> _designers;
        public ObservableCollection<Designer> Designers {
            get { return _designers; }
            set { SetProperty(ref _designers, value); }
        }

        public ICommand SelectedCommand => new Command(async (x) => {
            if (x is SelectionChangedEventArgs item) {
                if (item.CurrentSelection.FirstOrDefault() is Designer designer) {
                    await DialogService.ShowAlertAsync($"Designer name:{designer.DesignerName}" + Environment.NewLine + $"Description:{designer.Description}", "Selected designer", "OK");
                }
            }
        });

        /// <summary>
        ///     ctor().
        /// </summary>
        public DesignersContentViewModel() {
            GetDesigners();
        }

        public override void Dispose() {
            base.Dispose();

            ClearSource();
        }

        private void ClearSource() {
            Designers?.Clear();
        }

        public override Task InitializeAsync(object navigationData) {

            if (navigationData is SelectedContentArgs) {
                ClearSource();
                GetDesigners();
            }

            return base.InitializeAsync(navigationData);
        }

        private void GetDesigners() {
            Designers = new ObservableCollection<Designer> {
                new Designer {
                    ImgSource = "resource://FashFans.Resources.Images.im_armani.png",
                    DesignerName = "Giorgio Armani",
                    CommentCount = 13,
                    ImageAvatarUrl = "resource://FashFans.Resources.Images.im_armani_avatar.png",
                    LikeCount = 23,
                    Description = "imply dummy text of the printing and typesetting industry.",
                    Id = 1
                },
                 new Designer {
                     ImgSource = "resource://FashFans.Resources.Images.im_armani.png",
                     DesignerName = "Louis Vuitton",
                     CommentCount = 33,
                     ImageAvatarUrl = "resource://FashFans.Resources.Images.im_armani_avatar.png",
                     LikeCount = 23,
                     Description = "imply dummy text of the printing and typesetting industry.",
                     Id = 2
                },
                  new Designer {
                      ImgSource = "resource://FashFans.Resources.Images.im_yellow_scirt.png",
                      DesignerName = "Louis Vuitton",
                      CommentCount = 18,
                      ImageAvatarUrl = "resource://FashFans.Resources.Images.im_armani_avatar.png",
                      LikeCount = 23,
                      Description = "imply dummy text of the printing and typesetting industry.",
                      Id = 3
                },
                  new Designer {
                      ImgSource = "resource://FashFans.Resources.Images.im_yellow_scirt.png",
                      DesignerName = "Louis Vuitton",
                      CommentCount = 17,
                      ImageAvatarUrl = "resource://FashFans.Resources.Images.im_armani_avatar.png",
                      LikeCount = 23,
                      Description = "imply dummy text of the printing and typesetting industry.",
                      Id = 4
                },
            };
        }
    }
}
