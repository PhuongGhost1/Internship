using BE.Dto.Resources;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class ResourceMappers
    {
        public static Resource ToCreateResourceDto(this CreateResourceDto createResourceDto){
            return new Resource{
                Id = GenerateIdModel("resource"),
                Name = createResourceDto.Name
            };
        }

        public static Resource ToUpdateResourceDto(this UpdateResourceDto updateResourceDto){
            return new Resource{
                Name = updateResourceDto.Name
            };
        }
    }
}