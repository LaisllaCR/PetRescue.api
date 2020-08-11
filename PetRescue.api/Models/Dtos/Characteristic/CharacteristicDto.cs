namespace PetRescue.api.Models
{
    public class CharacteristicDto
    {
        public CharacteristicDto()
        {

        }

        public CharacteristicDto(Characteristics characteristic)
        {
            CharacteristicId = characteristic.CharacteristicId;
            Description = characteristic.Description;
        }

        public int CharacteristicId { get; set; }
        public string Description { get; set; }
    }
}
