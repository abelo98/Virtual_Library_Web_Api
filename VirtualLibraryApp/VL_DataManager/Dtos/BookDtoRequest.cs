using System.ComponentModel.DataAnnotations;

namespace VL_DataManager.Dtos
{
    public class BookDtoRequest:IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }


        [Required]
        [MaxLength(100)]
        public string EditorialName { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string DowloadUrl { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            int n = ISBN.Length;
            if (n != 10)
                yield return new ValidationResult(
                  $"ISbN incorrect length, must be 10 digits",
                  new[] { nameof(ISBN) });


            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = ISBN[i] - '0';

                if (0 > digit || 9 < digit)
                    yield return new ValidationResult(
                  $"{digit} not between 0 and 9",
                  new[] { nameof(ISBN) });

                sum += (digit * (10 - i));
            }

            // Checking last digit.
            char last = ISBN[9];
            if (last != 'X' && (last < '0'
                             || last > '9'))
                yield return new ValidationResult(
                   $"{last} not between 0 and 9",
                   new[] { nameof(ISBN) });


            sum += ((last == 'X') ? 10 :
                              (last - '0'));

        }
       
    }
}
