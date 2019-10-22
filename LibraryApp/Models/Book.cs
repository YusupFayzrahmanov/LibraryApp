using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibraryApp.Models
{
    /// <summary>
    /// Сущность книги
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(70)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        [MaxLength(50)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        [MaxLength(70)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Издательство")]
        public string PublishingHouse { get; set; }

        /// <summary>
        /// Краткое описание
        /// </summary>
        [MaxLength(200)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Год издания")]
        public DateTime Year { get; set; }
    }
}