import jsQR from "jsqr";
import { updatePersonStatus } from "../api/people";
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'

function StaffScan() {
  //@ts-expect-error stfu
  const handleFileUpload = async (event) => {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const img = new Image();
        //@ts-expect-error stfu
        img.src = e.target.result as string;
        img.onload = () => {
          const canvas = document.createElement("canvas");
          canvas.width = img.width;
          canvas.height = img.height;
          const ctx = canvas.getContext("2d");
          //@ts-expect-error stfu
          ctx.drawImage(img, 0, 0, img.width, img.height);
          //@ts-expect-error stfu
          const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
          const code = jsQR(imageData.data, imageData.width, imageData.height);
          if (code) {
            console.log(code.data);
			updatePersonStatus(code.data, true);

			withReactContent(Swal).fire({
				title: "Marked as present",
				icon: "success"
			});
          }
        };
      };
      reader.readAsDataURL(file);
    }
  };

  return (
    <div className="page" style={{ width: "100%", height: "100dvh" }}>
      <h1>Scan Participant</h1>
      <input type="file" accept="image/*" onChange={handleFileUpload} />
    </div>
  );
}

export default StaffScan;
