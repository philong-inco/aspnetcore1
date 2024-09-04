using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCrud2.Migrations
{
    public partial class refresh1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR2(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR2(255)", maxLength: 255, nullable: false),
                    PaymentMethod = table.Column<string>(type: "VARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR2(36)", maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR2(255 char)", nullable: false),
                    BuyerId = table.Column<string>(type: "VARCHAR2(36 char)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR2(36)", maxLength: 36, nullable: false),
                    Units = table.Column<string>(type: "VARCHAR2(255)", maxLength: 255, nullable: false),
                    UnitsPrice = table.Column<string>(type: "VARCHAR2(255)", maxLength: 255, nullable: false),
                    OrderId = table.Column<string>(type: "VARCHAR2(36)", maxLength: 36, nullable: false),
                    ProductId = table.Column<string>(type: "VARCHAR2(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "Id", "Name", "PaymentMethod" },
                values: new object[,]
                {
                    { "020931cc-9ddf-46a1-a1c7-5e2fa874bbb3", "Buyer 62", "Payment 62" },
                    { "023e7375-71ea-493d-858e-ccdf94d5ecea", "Buyer 35", "Payment 35" },
                    { "04623371-08c9-492c-9dcd-03d1100765a7", "Buyer 50", "Payment 50" },
                    { "04ec2908-1b92-4519-b06d-f22d099b0d8c", "Buyer 80", "Payment 80" },
                    { "09718277-51d6-4e7e-81c4-72082aa7e7ca", "Buyer 82", "Payment 82" },
                    { "0ab265ed-1a05-4c2f-92ba-919b6658e74d", "Buyer 71", "Payment 71" },
                    { "0c73b50a-87d8-46e3-a2f0-4640548bcc3c", "Buyer 54", "Payment 54" },
                    { "0ef94562-3658-4c6e-84a3-c972f011202a", "Buyer 55", "Payment 55" },
                    { "12912b6a-ac39-426f-95de-d0440476e7f2", "Buyer 47", "Payment 47" },
                    { "12eaa003-86e4-4e98-a1c7-1b11880df8ff", "Buyer 70", "Payment 70" },
                    { "1461afec-3226-45bc-a78d-7536d92f6b5c", "Buyer 83", "Payment 83" },
                    { "15c61054-d112-489a-994a-b8362126b00f", "Buyer 66", "Payment 66" },
                    { "1bf896e8-4eb1-46cb-be5d-2107ad36a7b7", "Buyer 20", "Payment 20" },
                    { "1d865de0-7e30-4c96-abf7-9410c1954344", "Buyer 31", "Payment 31" },
                    { "1f1dc4e8-df38-4ba7-a492-5ce6f01ea10c", "Buyer 73", "Payment 73" },
                    { "22acca7c-46f3-448b-9621-8b076bd707a0", "Buyer 42", "Payment 42" },
                    { "23a69885-789c-4c00-b612-d6078aa04f69", "Buyer 94", "Payment 94" },
                    { "2499a8a6-3a2a-4ea7-9601-d92cd1c36684", "Buyer 45", "Payment 45" },
                    { "2a93a12b-8f25-4926-842b-b29b702ede98", "Buyer 14", "Payment 14" },
                    { "2dab2334-5fe3-4ac5-817e-bb16fdb2aa46", "Buyer 34", "Payment 34" },
                    { "33a48738-3af4-48fc-a011-977b7f64bc4e", "Buyer 23", "Payment 23" },
                    { "3c28b35f-3b68-4e6d-8933-b6457b90ed6c", "Buyer 53", "Payment 53" },
                    { "3eb4e997-3c24-4440-9964-c4a70d54608a", "Buyer 21", "Payment 21" },
                    { "41010e3a-6aec-4c20-a463-e3f32984b539", "Buyer 9", "Payment 9" },
                    { "412a238c-5338-4815-aac7-ec14be06f996", "Buyer 29", "Payment 29" },
                    { "41d23bc9-f664-4188-a428-4ac4c839ef51", "Buyer 13", "Payment 13" },
                    { "431bba15-4bfd-44f9-afde-8860c08143ed", "Buyer 6", "Payment 6" },
                    { "447d861d-aa5e-442e-a539-bc147ca2532a", "Buyer 22", "Payment 22" },
                    { "45b64997-b38a-4c69-a51b-74b2bacee77f", "Buyer 24", "Payment 24" },
                    { "47286093-c00f-4eea-aede-04f75550d22b", "Buyer 91", "Payment 91" },
                    { "4860e4d4-efbc-4714-886a-373fc2c93c70", "Buyer 89", "Payment 89" },
                    { "4a09d000-7fe0-4092-80a8-b185f05287d8", "Buyer 67", "Payment 67" },
                    { "4ca4af36-0f83-422f-afc3-9f4600e04ec8", "Buyer 93", "Payment 93" },
                    { "4f1a640f-db45-4c7b-853e-c8f24f7a4312", "Buyer 36", "Payment 36" },
                    { "510dc86a-b9e6-4e77-a661-eee40d93fe1b", "Buyer 81", "Payment 81" },
                    { "5308ee08-dc51-40e7-b6fe-1b3e2e3cb4fb", "Buyer 7", "Payment 7" },
                    { "582521e3-f543-445a-a49a-20292ff606d7", "Buyer 40", "Payment 40" },
                    { "59841e4a-632f-4696-a4ad-49cce2ce0aaa", "Buyer 41", "Payment 41" },
                    { "5affacfb-f421-49ab-bf0a-eee2e3811b99", "Buyer 92", "Payment 92" },
                    { "619f204a-8e06-44df-965f-7dc189dbb3d2", "Buyer 8", "Payment 8" },
                    { "61ab471c-5e1e-4d9b-af85-b6eaee865f98", "Buyer 10", "Payment 10" },
                    { "66213d0e-99a4-4b83-bd0d-7642af8bf91e", "Buyer 79", "Payment 79" }
                });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "Id", "Name", "PaymentMethod" },
                values: new object[,]
                {
                    { "6655e2e9-f2b4-4a4a-9e13-9314ca968850", "Buyer 65", "Payment 65" },
                    { "67616f63-6977-49e8-bea7-839b4fcd7446", "Buyer 75", "Payment 75" },
                    { "6a878b0e-aa8b-47d5-9b13-1cb53bff39f1", "Buyer 30", "Payment 30" },
                    { "6a8e2797-ce9c-484b-af27-6ed51a2d4655", "Buyer 74", "Payment 74" },
                    { "6b28c2be-4611-4b7f-8f16-4c6ce2cdbc1a", "Buyer 61", "Payment 61" },
                    { "6d176317-85a9-4e31-9026-28ca74fb6071", "Buyer 25", "Payment 25" },
                    { "71bb95e1-c705-4335-b60f-cf94c3f6148b", "Buyer 77", "Payment 77" },
                    { "7526c390-3c9d-41cb-8a50-d0194db52e3a", "Buyer 76", "Payment 76" },
                    { "773f0caa-4b9e-495e-9efa-e28361a4e82f", "Buyer 43", "Payment 43" },
                    { "7c164380-b80f-4085-ad26-7ea59638e416", "Buyer 46", "Payment 46" },
                    { "7de70f0b-fc87-47ba-a37b-a7bd7691016b", "Buyer 56", "Payment 56" },
                    { "7deda979-9af9-4083-a1dc-b453a8d8949b", "Buyer 27", "Payment 27" },
                    { "7ee3928e-31b1-458a-a0be-1e1d266ea4b3", "Buyer 32", "Payment 32" },
                    { "830ac638-f252-4a17-bf1c-fee21946f059", "Buyer 68", "Payment 68" },
                    { "842dc8de-1c15-42a5-8899-7997048a9e5c", "Buyer 63", "Payment 63" },
                    { "8a734fc9-3f07-4de8-bb46-089c0c3802dc", "Buyer 51", "Payment 51" },
                    { "8ad1c245-0d6e-4137-9070-e3e4cae82d31", "Buyer 12", "Payment 12" },
                    { "8e9019be-28f3-4654-a75b-e4f642399385", "Buyer 100", "Payment 100" },
                    { "90274cf8-6df4-4ad3-a234-5acb8c5e57bf", "Buyer 57", "Payment 57" },
                    { "9128b40d-be4f-4ea5-8892-39174d282c6b", "Buyer 16", "Payment 16" },
                    { "950606a2-d79d-4ac3-ac80-8bcc3690127f", "Buyer 99", "Payment 99" },
                    { "9692dd27-0670-43d8-b33e-fb263d0f143d", "Buyer 39", "Payment 39" },
                    { "975d68fb-9efa-44ae-9748-a18a065a754e", "Buyer 19", "Payment 19" },
                    { "9b6d9fd8-e380-4afb-8f43-ec18bae98404", "Buyer 85", "Payment 85" },
                    { "9b9fcebd-bf27-4549-9fca-b76009d144c3", "Buyer 2", "Payment 2" },
                    { "9eaa83d1-c98c-4d36-9814-b0f9a4cb3610", "Buyer 1", "Payment 1" },
                    { "a0968277-3a5d-4697-bba0-52842ed8397c", "Buyer 78", "Payment 78" },
                    { "a68b3ac3-8a23-4078-8c3a-e185d6fa284d", "Buyer 33", "Payment 33" },
                    { "a88f6e08-d11a-4333-a3a9-f60ff20f4d3d", "Buyer 52", "Payment 52" },
                    { "a97349f0-cccf-4064-ae55-8c1644da875e", "Buyer 48", "Payment 48" },
                    { "ac232852-c5b0-4067-8420-83084f0549b7", "Buyer 88", "Payment 88" },
                    { "ad1a6810-975c-4aec-b8cd-e49f2430e4f4", "Buyer 18", "Payment 18" },
                    { "b06b25d0-119e-40fb-ad06-17dd8bdbda9b", "Buyer 96", "Payment 96" },
                    { "b7714b40-f8b7-4da8-82c5-eb7a3be6a8f3", "Buyer 26", "Payment 26" },
                    { "ba54cea3-1157-4175-9eb2-6884c977c977", "Buyer 4", "Payment 4" },
                    { "bb7dfc09-c8fd-4936-8736-69ffcb237a16", "Buyer 5", "Payment 5" },
                    { "beac42dd-6d7d-499e-ae30-5829d4106b06", "Buyer 86", "Payment 86" },
                    { "bf046c83-6e0e-4eec-8e2f-a7de5a9d9984", "Buyer 69", "Payment 69" },
                    { "c12e0dab-003e-4e85-abee-c6736bb3a25b", "Buyer 58", "Payment 58" },
                    { "c5fd46bb-9acb-435d-9ee9-92a8f52dad56", "Buyer 15", "Payment 15" },
                    { "ca5b24d8-4f3e-4473-9040-3c22196ec07a", "Buyer 60", "Payment 60" },
                    { "ccf2ab5d-dd14-48ee-8041-bf54c3104fcb", "Buyer 98", "Payment 98" }
                });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "Id", "Name", "PaymentMethod" },
                values: new object[,]
                {
                    { "ce9843ca-ddc6-440c-a503-bf946294dc5d", "Buyer 37", "Payment 37" },
                    { "d0d772de-50f1-4645-87ca-362bf15c06d3", "Buyer 95", "Payment 95" },
                    { "d0ed23b6-dabd-4253-90c0-b384dca817b4", "Buyer 97", "Payment 97" },
                    { "d65da600-a9fe-43ed-8049-1eae4d6637eb", "Buyer 64", "Payment 64" },
                    { "dc0c2329-a9d5-4f57-93f2-b8f4b1976912", "Buyer 72", "Payment 72" },
                    { "dce28573-5331-43b0-85e9-7988d7fa03a9", "Buyer 59", "Payment 59" },
                    { "e1866d23-e8c3-4e5e-8b45-ab3049a15703", "Buyer 3", "Payment 3" },
                    { "e2edc73d-9fef-41ea-9c1c-e9570936850c", "Buyer 84", "Payment 84" },
                    { "e3ae130b-242f-4ec5-9b93-617acf252a81", "Buyer 87", "Payment 87" },
                    { "e4beea52-c05c-4680-b655-261cbc521530", "Buyer 11", "Payment 11" },
                    { "e91cf325-c5b6-436d-bad7-161a06bdb081", "Buyer 38", "Payment 38" },
                    { "f04dda8e-bae8-4345-81bc-818bae3888f5", "Buyer 90", "Payment 90" },
                    { "f0b40d94-68b9-4d11-ab91-0d71c6203cba", "Buyer 44", "Payment 44" },
                    { "f5dfab4e-ef34-4743-9e14-ec032d3d97cb", "Buyer 17", "Payment 17" },
                    { "f9679ff2-53f0-4aab-8b20-acb98e6187be", "Buyer 28", "Payment 28" },
                    { "fb033c80-4e5f-4824-969f-e9b5bc011711", "Buyer 49", "Payment 49" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "BuyerId", "CreateDate", "Status" },
                values: new object[,]
                {
                    { "03383b8f-8c1c-4293-9be5-7bd4731c0350", "Address 98", "ccf2ab5d-dd14-48ee-8041-bf54c3104fcb", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(2026), 1 },
                    { "03e8befc-4938-4eae-9b25-92db874665ed", "Address 77", "71bb95e1-c705-4335-b60f-cf94c3f6148b", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1547), 1 },
                    { "05f184e9-aa58-477f-9574-c1956c350afa", "Address 57", "90274cf8-6df4-4ad3-a234-5acb8c5e57bf", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(863), 1 },
                    { "0b1e293f-e4b0-4045-a1cf-abdd31f03d8e", "Address 75", "67616f63-6977-49e8-bea7-839b4fcd7446", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1461), 1 },
                    { "0b538536-7030-4e71-b6b9-4d0732fa5dd9", "Address 38", "e91cf325-c5b6-436d-bad7-161a06bdb081", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(389), 1 },
                    { "0c7af229-bbd2-4ef0-9e0a-a297710a504b", "Address 80", "04ec2908-1b92-4519-b06d-f22d099b0d8c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1604), 1 },
                    { "0de21f94-c617-46f7-872f-e8603e4f3480", "Address 17", "f5dfab4e-ef34-4743-9e14-ec032d3d97cb", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9930), 1 },
                    { "0fe7016d-b97f-4336-bd2e-2d958f291b77", "Address 88", "ac232852-c5b0-4067-8420-83084f0549b7", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1785), 1 },
                    { "10e647a2-3a7c-4acf-af79-962972f33037", "Address 84", "e2edc73d-9fef-41ea-9c1c-e9570936850c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1711), 1 },
                    { "1241d27e-e2ba-41dc-9411-a86edcbb4d5a", "Address 24", "45b64997-b38a-4c69-a51b-74b2bacee77f", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(63), 1 },
                    { "12456666-40f5-47cd-99ec-05df3e52361a", "Address 85", "9b6d9fd8-e380-4afb-8f43-ec18bae98404", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1730), 1 },
                    { "16b72e34-d406-4a48-88b4-ecdcdd0d5728", "Address 29", "412a238c-5338-4815-aac7-ec14be06f996", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(189), 1 },
                    { "1af71c09-4421-4db3-aebd-656b83a9be4c", "Address 6", "431bba15-4bfd-44f9-afde-8860c08143ed", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9645), 1 },
                    { "1c113218-c521-4e60-921d-86f8eabe0137", "Address 64", "d65da600-a9fe-43ed-8049-1eae4d6637eb", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1080), 1 },
                    { "2418ff4f-4d5c-4692-8387-5f18854c7fbc", "Address 99", "950606a2-d79d-4ac3-ac80-8bcc3690127f", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(2045), 1 },
                    { "244e1705-8436-4595-8f5f-e4c3f8ee46db", "Address 96", "b06b25d0-119e-40fb-ad06-17dd8bdbda9b", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1964), 1 },
                    { "24d362e5-11a3-4bf6-99ac-73d3bbb310fd", "Address 49", "fb033c80-4e5f-4824-969f-e9b5bc011711", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(645), 1 },
                    { "25c10fe7-92be-4b27-810c-e3aa35c037ce", "Address 31", "1d865de0-7e30-4c96-abf7-9410c1954344", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(226), 1 },
                    { "2605551c-ed6e-42a7-95ae-60eac3100c36", "Address 36", "4f1a640f-db45-4c7b-853e-c8f24f7a4312", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(350), 1 },
                    { "2ef8a040-3fd7-4474-90a8-3c487e63ef0f", "Address 19", "975d68fb-9efa-44ae-9748-a18a065a754e", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9969), 1 },
                    { "30f13849-9c1f-4cff-af43-eddafb9dfb98", "Address 4", "ba54cea3-1157-4175-9eb2-6884c977c977", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9605), 1 },
                    { "3244bcd4-c097-4b36-8c8f-a4ad59a3b3a8", "Address 56", "7de70f0b-fc87-47ba-a37b-a7bd7691016b", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(839), 1 },
                    { "3474d1f8-9372-4790-9d73-904bb5be4212", "Address 82", "09718277-51d6-4e7e-81c4-72082aa7e7ca", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1645), 1 },
                    { "38f7e726-a017-435f-89b0-0fc5e32f81fe", "Address 47", "12912b6a-ac39-426f-95de-d0440476e7f2", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(607), 1 },
                    { "3c21170c-941a-4c1a-b659-e96752f1a6e7", "Address 15", "c5fd46bb-9acb-435d-9ee9-92a8f52dad56", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9845), 1 },
                    { "41000f1b-b781-4c64-80b1-d10e01b7ae84", "Address 27", "7deda979-9af9-4083-a1dc-b453a8d8949b", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(149), 1 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "BuyerId", "CreateDate", "Status" },
                values: new object[,]
                {
                    { "41a13973-badd-43d5-8066-f44335bd2bf8", "Address 94", "23a69885-789c-4c00-b612-d6078aa04f69", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1928), 1 },
                    { "449e7da0-971c-4940-b3fa-d437c6a761a3", "Address 78", "a0968277-3a5d-4697-bba0-52842ed8397c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1567), 1 },
                    { "465c76bb-b62e-49b2-9742-07330a816e06", "Address 65", "6655e2e9-f2b4-4a4a-9e13-9314ca968850", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1101), 1 },
                    { "47e729a2-8c0c-4cc0-afb6-c249f4a5ac4e", "Address 89", "4860e4d4-efbc-4714-886a-373fc2c93c70", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1805), 1 },
                    { "4b3cf246-78cc-4ae6-b203-9f30ab39bc1a", "Address 34", "2dab2334-5fe3-4ac5-817e-bb16fdb2aa46", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(312), 1 },
                    { "4c359f18-d169-4f05-a193-bc366bd3976a", "Address 43", "773f0caa-4b9e-495e-9efa-e28361a4e82f", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(508), 1 },
                    { "4c7ce33e-82be-4bd1-8bda-ba62b79eb43f", "Address 16", "9128b40d-be4f-4ea5-8892-39174d282c6b", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9865), 1 },
                    { "5571032d-c247-4949-b5a8-8e1f0e188e21", "Address 69", "bf046c83-6e0e-4eec-8e2f-a7de5a9d9984", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1222), 1 },
                    { "567853f7-acf5-4571-a8d7-d7c416fa3e17", "Address 86", "beac42dd-6d7d-499e-ae30-5829d4106b06", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1751), 1 },
                    { "580ce179-a426-4e61-81ae-0d20f8e6e8b0", "Address 2", "9b9fcebd-bf27-4549-9fca-b76009d144c3", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9563), 1 },
                    { "58452626-da83-4094-b47e-3d71bfb39364", "Address 37", "ce9843ca-ddc6-440c-a503-bf946294dc5d", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(370), 1 },
                    { "5909ec24-7955-4207-950f-40d60ae654e4", "Address 22", "447d861d-aa5e-442e-a539-bc147ca2532a", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(26), 1 },
                    { "640370f8-56d1-44ff-9c3c-ba45e24dd728", "Address 10", "61ab471c-5e1e-4d9b-af85-b6eaee865f98", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9750), 1 },
                    { "647c7385-9cff-4d94-8f75-f9fa655aff36", "Address 32", "7ee3928e-31b1-458a-a0be-1e1d266ea4b3", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(273), 1 },
                    { "65b2669e-c78f-485a-a9ab-4bbc2555c2b3", "Address 81", "510dc86a-b9e6-4e77-a661-eee40d93fe1b", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1625), 1 },
                    { "6632a15d-1d19-45f2-9290-868e349dbd56", "Address 74", "6a8e2797-ce9c-484b-af27-6ed51a2d4655", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1441), 1 },
                    { "6661786a-a76a-42db-9fea-a2f7fcaa896d", "Address 28", "f9679ff2-53f0-4aab-8b20-acb98e6187be", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(169), 1 },
                    { "66e86ce5-05a2-4120-90c3-89ab62465f1c", "Address 41", "59841e4a-632f-4696-a4ad-49cce2ce0aaa", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(470), 1 },
                    { "6759c88c-c143-4e4c-9cb3-e6ed434b2845", "Address 60", "ca5b24d8-4f3e-4473-9040-3c22196ec07a", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(941), 1 },
                    { "68e55a07-d314-4155-b146-c5cc76431208", "Address 11", "e4beea52-c05c-4680-b655-261cbc521530", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9769), 1 },
                    { "69c323ad-192c-4961-82c2-dd1e578d5905", "Address 70", "12eaa003-86e4-4e98-a1c7-1b11880df8ff", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1246), 1 },
                    { "6ab87df3-54d6-4d13-889a-a3f102ee7e2e", "Address 52", "a88f6e08-d11a-4333-a3a9-f60ff20f4d3d", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(712), 1 },
                    { "6cc474f1-1254-4dc2-933e-f3650dca97d9", "Address 23", "33a48738-3af4-48fc-a011-977b7f64bc4e", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(43), 1 },
                    { "6f646a98-3e97-4e75-9ba3-d73d72e74d12", "Address 97", "d0ed23b6-dabd-4253-90c0-b384dca817b4", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(2007), 1 },
                    { "725a6922-5ea7-4f88-85e3-4b38d9a40f5b", "Address 8", "619f204a-8e06-44df-965f-7dc189dbb3d2", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9683), 1 },
                    { "730e415f-f572-4452-b9f3-de08c230ba9f", "Address 3", "e1866d23-e8c3-4e5e-8b45-ab3049a15703", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9586), 1 },
                    { "79a766d2-5cc6-446d-937b-54682a86d0db", "Address 26", "b7714b40-f8b7-4da8-82c5-eb7a3be6a8f3", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(129), 1 },
                    { "7af662d6-1e2b-40b2-9043-d966bdf68bc9", "Address 9", "41010e3a-6aec-4c20-a463-e3f32984b539", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9702), 1 },
                    { "7cdf257e-c131-49a9-8191-423840035bd3", "Address 53", "3c28b35f-3b68-4e6d-8933-b6457b90ed6c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(737), 1 },
                    { "806aa546-6ff0-4839-ac4a-b5cfa8b9ce61", "Address 25", "6d176317-85a9-4e31-9026-28ca74fb6071", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(110), 1 },
                    { "81045ce3-414a-4fe7-a9c5-4296167fc1c8", "Address 72", "dc0c2329-a9d5-4f57-93f2-b8f4b1976912", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1297), 1 },
                    { "85618ec4-5b4b-487d-95ce-db47e1fda15a", "Address 51", "8a734fc9-3f07-4de8-bb46-089c0c3802dc", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(686), 1 },
                    { "864b85c8-3420-4eef-9b69-3ac8ca8d75a8", "Address 93", "4ca4af36-0f83-422f-afc3-9f4600e04ec8", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1909), 1 },
                    { "8b3ee814-4652-4872-9f8f-5342c558df29", "Address 73", "1f1dc4e8-df38-4ba7-a492-5ce6f01ea10c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1420), 1 },
                    { "8bfcdced-22cf-4496-bfcc-4b65f1040e36", "Address 5", "bb7dfc09-c8fd-4936-8736-69ffcb237a16", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9625), 1 },
                    { "8ce2f287-2337-4231-99c9-b9b73f3fa26e", "Address 30", "6a878b0e-aa8b-47d5-9b13-1cb53bff39f1", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(210), 1 },
                    { "8cf7f28d-8c72-48cf-bbc0-215fc1b17628", "Address 92", "5affacfb-f421-49ab-bf0a-eee2e3811b99", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1889), 1 },
                    { "983c5449-1d58-4997-a275-17aedd643921", "Address 39", "9692dd27-0670-43d8-b33e-fb263d0f143d", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(431), 1 },
                    { "98e3ba92-658b-43a3-be7a-01cc5aab19de", "Address 13", "41d23bc9-f664-4188-a428-4ac4c839ef51", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9808), 1 },
                    { "9c64db94-347a-4d23-8430-e21e90052cd2", "Address 40", "582521e3-f543-445a-a49a-20292ff606d7", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(451), 1 },
                    { "a0a23211-8024-4fa7-a625-6118441f8404", "Address 44", "f0b40d94-68b9-4d11-ab91-0d71c6203cba", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(527), 1 },
                    { "a3bae388-09be-4621-b94d-bbcbcf4b5782", "Address 68", "830ac638-f252-4a17-bf1c-fee21946f059", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1198), 1 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "BuyerId", "CreateDate", "Status" },
                values: new object[,]
                {
                    { "a4c005e9-e5ac-4ec9-b14e-f8e4de380833", "Address 18", "ad1a6810-975c-4aec-b8cd-e49f2430e4f4", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9950), 1 },
                    { "a5593fac-82dc-4e53-a64b-4f1c89649197", "Address 1", "9eaa83d1-c98c-4d36-9814-b0f9a4cb3610", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9482), 1 },
                    { "a60c44a0-90c5-4412-bdfa-6358d9006aa4", "Address 100", "8e9019be-28f3-4654-a75b-e4f642399385", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(2064), 1 },
                    { "a809d0b8-1e52-44a4-a6f9-839f889ab40d", "Address 50", "04623371-08c9-492c-9dcd-03d1100765a7", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(665), 1 },
                    { "a995b4cc-0bb1-4ffb-9620-eed1ba39503f", "Address 71", "0ab265ed-1a05-4c2f-92ba-919b6658e74d", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1271), 1 },
                    { "ae85b298-86cd-4316-a1b2-b277ee0c4f40", "Address 12", "8ad1c245-0d6e-4137-9070-e3e4cae82d31", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9790), 1 },
                    { "b0a63f4e-420a-43e5-861f-49c2cc14d673", "Address 63", "842dc8de-1c15-42a5-8899-7997048a9e5c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1053), 1 },
                    { "bd2d1a1a-f3df-40c7-8bc3-0c8cdcaceb46", "Address 45", "2499a8a6-3a2a-4ea7-9601-d92cd1c36684", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(546), 1 },
                    { "bdd43f47-dcfe-44c6-807f-782a54f83f0b", "Address 55", "0ef94562-3658-4c6e-84a3-c972f011202a", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(816), 1 },
                    { "bedb7e71-694a-491c-85fc-83d67ee745cb", "Address 67", "4a09d000-7fe0-4092-80a8-b185f05287d8", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1138), 1 },
                    { "c453129b-d199-455f-9ac6-8bd39cada04c", "Address 20", "1bf896e8-4eb1-46cb-be5d-2107ad36a7b7", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9989), 1 },
                    { "cf7719a5-c117-4f75-baf4-0d6e7e53bb56", "Address 33", "a68b3ac3-8a23-4078-8c3a-e185d6fa284d", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(291), 1 },
                    { "d235787c-5820-4896-aeec-77c189d6ae7b", "Address 46", "7c164380-b80f-4085-ad26-7ea59638e416", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(590), 1 },
                    { "d74049b0-7606-47cd-a3b8-c60b4479be80", "Address 76", "7526c390-3c9d-41cb-8a50-d0194db52e3a", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1528), 1 },
                    { "d7c4e026-ecc3-4be2-9a81-8fbfc87bef5a", "Address 83", "1461afec-3226-45bc-a78d-7536d92f6b5c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1692), 1 },
                    { "d7c766c3-443d-4c1a-82dd-cf809a34db72", "Address 90", "f04dda8e-bae8-4345-81bc-818bae3888f5", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1850), 1 },
                    { "de5c42e8-a230-420c-914e-b852a350f668", "Address 61", "6b28c2be-4611-4b7f-8f16-4c6ce2cdbc1a", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1006), 1 },
                    { "deb7f815-41b4-4ac4-b5b5-b9a7d8134add", "Address 91", "47286093-c00f-4eea-aede-04f75550d22b", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1869), 1 },
                    { "e32d4bce-0a7c-4df4-9c34-8b9c6378da73", "Address 66", "15c61054-d112-489a-994a-b8362126b00f", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1120), 1 },
                    { "e542fac6-4621-405f-8799-4479e3f5da39", "Address 35", "023e7375-71ea-493d-858e-ccdf94d5ecea", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(331), 1 },
                    { "e5830ae0-9b2c-4fba-a631-674ddc5063d8", "Address 48", "a97349f0-cccf-4064-ae55-8c1644da875e", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(627), 1 },
                    { "e79a6954-4d41-46aa-a095-deae095ba699", "Address 58", "c12e0dab-003e-4e85-abee-c6736bb3a25b", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(892), 1 },
                    { "ea2ea746-67b9-44cd-9727-eca7a06ef710", "Address 79", "66213d0e-99a4-4b83-bd0d-7642af8bf91e", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1584), 1 },
                    { "ea670384-2d82-4839-a938-d3df934cf98d", "Address 42", "22acca7c-46f3-448b-9621-8b076bd707a0", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(490), 1 },
                    { "eb2a4966-8610-4fcb-9d49-3655c5a633e4", "Address 21", "3eb4e997-3c24-4440-9964-c4a70d54608a", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(7), 1 },
                    { "ec45b1ae-4d6e-40b8-9f8f-b2273ee70fbc", "Address 14", "2a93a12b-8f25-4926-842b-b29b702ede98", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9829), 1 },
                    { "ee0e34ac-cd4a-4b4d-9a3b-dd84ca45f4a6", "Address 95", "d0d772de-50f1-4645-87ca-362bf15c06d3", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1945), 1 },
                    { "eee010b8-dae0-484f-90d1-a3ceef01532b", "Address 59", "dce28573-5331-43b0-85e9-7988d7fa03a9", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(916), 1 },
                    { "f297d8ed-97d9-420b-b57a-2475806e8039", "Address 54", "0c73b50a-87d8-46e3-a2f0-4640548bcc3c", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(797), 1 },
                    { "f6a3acf0-c2c8-442a-a432-51bd3639f971", "Address 87", "e3ae130b-242f-4ec5-9b93-617acf252a81", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1767), 1 },
                    { "fcc767db-c78e-4e9e-a01b-20ef87926517", "Address 62", "020931cc-9ddf-46a1-a1c7-5e2fa874bbb3", new DateTime(2024, 8, 28, 11, 42, 7, 298, DateTimeKind.Local).AddTicks(1031), 1 },
                    { "fdef0463-75ee-4572-92c6-3bbc0209cd42", "Address 7", "5308ee08-dc51-40e7-b6fe-1b3e2e3cb4fb", new DateTime(2024, 8, 28, 11, 42, 7, 297, DateTimeKind.Local).AddTicks(9662), 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Units", "UnitsPrice" },
                values: new object[,]
                {
                    { "00dda9ae-bfb5-4617-bbaf-af5d0a26d0cf", "05f184e9-aa58-477f-9574-c1956c350afa", "8aa2152a-54fb-492d-bcb3-9a111bac6ece", "156", "256" },
                    { "01bda488-7348-4846-ab01-1229abb9da1d", "a4c005e9-e5ac-4ec9-b14e-f8e4de380833", "b72caf7a-13fd-4e80-9ead-95951a4f9fe1", "117", "217" },
                    { "0891925f-24d0-4ff9-8f55-e0e6ef01f482", "e5830ae0-9b2c-4fba-a631-674ddc5063d8", "6db8e91c-729f-4ce2-9af5-8933ee169a27", "147", "247" },
                    { "0a30ff6d-0ed6-414c-aeed-c0dcabce30f4", "983c5449-1d58-4997-a275-17aedd643921", "4cab78e5-9cd4-4f0e-be6b-eb59c2d276ce", "138", "238" },
                    { "0c4d08d7-2224-4fb6-a9aa-aef1c50e9909", "1af71c09-4421-4db3-aebd-656b83a9be4c", "6e0d0286-c4fa-4a04-af16-c41168a95d83", "105", "205" },
                    { "0d58a878-8787-4ba3-9326-7a96f53086c1", "ae85b298-86cd-4316-a1b2-b277ee0c4f40", "2d6fca29-b2f1-46aa-b47c-79e1cdf133d2", "111", "211" },
                    { "0f9bb2d2-a68b-4fd5-a63a-df98692f5852", "7cdf257e-c131-49a9-8191-423840035bd3", "c518d21c-7dd7-417c-bcc4-e9a49f576aec", "152", "252" },
                    { "106cab50-aa17-4b25-9944-83c4d2797b24", "fdef0463-75ee-4572-92c6-3bbc0209cd42", "ffc58228-e7fc-41aa-8e88-f7bb08f07c03", "106", "206" },
                    { "133edc7f-1541-45aa-b5dc-f3fbc2428ebb", "12456666-40f5-47cd-99ec-05df3e52361a", "8717b93f-014e-49a6-9ed3-a78ddb4e267d", "184", "284" },
                    { "14bb2214-aab5-43a1-852a-66862580bd0c", "8b3ee814-4652-4872-9f8f-5342c558df29", "cb05ba89-c10c-42ec-9c2a-3cc37fe3a453", "172", "272" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Units", "UnitsPrice" },
                values: new object[,]
                {
                    { "1748342f-c985-4ce5-ae19-431ca1456ba7", "1241d27e-e2ba-41dc-9411-a86edcbb4d5a", "7d9e6c02-026b-44fe-849f-10b06ef41ae0", "123", "223" },
                    { "18702c3c-c423-48a7-81d9-3483f8d99ad1", "2605551c-ed6e-42a7-95ae-60eac3100c36", "cdb8ccaf-0ec2-4ed9-8806-054c642322d2", "135", "235" },
                    { "19e8eb53-7724-43ab-af4a-ca76a26a28c1", "81045ce3-414a-4fe7-a9c5-4296167fc1c8", "465ca99f-af3a-43eb-b00f-65de1adb200e", "171", "271" },
                    { "19f27b49-6c0e-448b-859a-1be7042f1169", "68e55a07-d314-4155-b146-c5cc76431208", "7ebbf97e-9bdb-4d2c-8b6f-1f18db7b9310", "110", "210" },
                    { "1a3e1e57-9a08-4f89-85c4-895130ca07a1", "bedb7e71-694a-491c-85fc-83d67ee745cb", "6966572a-54a7-4f71-9a3c-bc36de711a56", "166", "266" },
                    { "1ab73d49-5e19-4944-b20c-90ddc32f487d", "a0a23211-8024-4fa7-a625-6118441f8404", "9879be3a-6b87-4b2d-b81a-2a4294aa6d26", "143", "243" },
                    { "1ba1fa52-30bd-4451-b79b-7732586342e0", "8bfcdced-22cf-4496-bfcc-4b65f1040e36", "de3a9e5d-57b3-43fa-b706-76d4d2a819d2", "104", "204" },
                    { "24121b8f-2c5b-4927-960c-4189d39380fa", "465c76bb-b62e-49b2-9742-07330a816e06", "fd82c807-fd4c-41e1-a77e-7b430dd34486", "164", "264" },
                    { "251392ad-a847-4dcb-b71c-b711ad643c7d", "eee010b8-dae0-484f-90d1-a3ceef01532b", "2245e45b-5918-4b29-9aa4-a7e434abf839", "158", "258" },
                    { "2b90b667-7f48-4b81-a888-7e8ef26208a5", "ec45b1ae-4d6e-40b8-9f8f-b2273ee70fbc", "a22a345f-1777-4ebb-a78f-fbaaa34f8d02", "113", "213" },
                    { "2f788100-d5a7-4c0b-9159-5333a5f191e0", "03383b8f-8c1c-4293-9be5-7bd4731c0350", "ac2058fb-fbca-4310-bc6c-3b451cd91856", "197", "297" },
                    { "3277b630-4ff6-42bc-99cb-49047105c145", "65b2669e-c78f-485a-a9ab-4bbc2555c2b3", "1d59c7e8-fe16-491c-8acb-a077d9d612ad", "180", "280" },
                    { "349e457d-7529-4ebd-a3e1-5c16cd5065d2", "3244bcd4-c097-4b36-8c8f-a4ad59a3b3a8", "b76fa201-ec96-4fc9-86b7-a8430d6d211a", "155", "255" },
                    { "34bdd047-b79a-449c-900d-e991848dc1fa", "eb2a4966-8610-4fcb-9d49-3655c5a633e4", "1706207e-713f-4dd4-a054-3b7e26b873bd", "120", "220" },
                    { "37059cb8-d036-41ea-b06c-f0ab9990de93", "449e7da0-971c-4940-b3fa-d437c6a761a3", "5f3bd44f-f36c-4209-aeb1-6b73d5237b38", "177", "277" },
                    { "37df965e-6246-40c2-8f17-79e21889d010", "567853f7-acf5-4571-a8d7-d7c416fa3e17", "f9173fe9-2dee-4664-bbf6-3a38ecb077d5", "185", "285" },
                    { "3aa31c9e-cfcc-406d-be82-fea86048ee55", "cf7719a5-c117-4f75-baf4-0d6e7e53bb56", "13ad9368-f077-43cf-9b97-702ee4d755b6", "132", "232" },
                    { "3b4337a1-58fb-4ba0-b7d8-b485fb54e589", "bd2d1a1a-f3df-40c7-8bc3-0c8cdcaceb46", "15bc3ef8-b792-47df-8b07-73756cdd9e79", "144", "244" },
                    { "3e90f829-badd-4518-95ad-6db08eb33b2d", "730e415f-f572-4452-b9f3-de08c230ba9f", "e67d1465-7f43-41d3-b429-0ec4ef8d4085", "102", "202" },
                    { "455b83a6-35fc-462d-9a6a-ebbe1d66beb1", "0fe7016d-b97f-4336-bd2e-2d958f291b77", "35c1c10c-1a16-4271-a7b0-54cab9787778", "187", "287" },
                    { "483ca57a-eda3-4436-844b-c1f29d6d8e52", "30f13849-9c1f-4cff-af43-eddafb9dfb98", "6cff2b26-20c3-40f9-84ef-f3ed8834c15a", "103", "203" },
                    { "48656a2d-b916-499d-8ca4-275e5010d523", "a3bae388-09be-4621-b94d-bbcbcf4b5782", "09db617a-71a4-477f-b1cb-e2931150539d", "167", "267" },
                    { "489e4109-3d73-4ac5-b2ac-7afee31e2215", "fcc767db-c78e-4e9e-a01b-20ef87926517", "197343a0-4434-4444-a072-44a1f343c2f0", "161", "261" },
                    { "49e6fd15-2d13-4685-bc00-f658475f1964", "e32d4bce-0a7c-4df4-9c34-8b9c6378da73", "f5d7116a-b91e-4501-b7a2-de0412f79dbd", "165", "265" },
                    { "4a5836de-4186-40f2-847a-4627dab0ed19", "e542fac6-4621-405f-8799-4479e3f5da39", "6cf78ef6-d77a-4674-bbc3-42beafbb96d0", "134", "234" },
                    { "50c8791d-f643-43fe-9294-231a11e231fb", "41a13973-badd-43d5-8066-f44335bd2bf8", "df314530-a888-45fb-99fa-1d42028e0424", "193", "293" },
                    { "513d2806-b337-4503-9103-048e75391c78", "f6a3acf0-c2c8-442a-a432-51bd3639f971", "f23038d7-0310-464d-be31-31d68548dd14", "186", "286" },
                    { "51836e5a-361d-4822-8cb5-30644d366d0c", "b0a63f4e-420a-43e5-861f-49c2cc14d673", "af966745-c03f-4f2a-be73-ac1386b0994f", "162", "262" },
                    { "51d16f33-ca82-4691-adeb-64a2fa92f31d", "38f7e726-a017-435f-89b0-0fc5e32f81fe", "0e4f10dc-9e34-4ec0-92df-ac509449a0b1", "146", "246" },
                    { "51d9db1a-715e-4341-be4c-6ded560a9afe", "e79a6954-4d41-46aa-a095-deae095ba699", "28c94826-5dbc-4cb9-9706-a6112d772f7b", "157", "257" },
                    { "5828397e-4b0d-4cf1-a8c2-b1302f8685d1", "2418ff4f-4d5c-4692-8387-5f18854c7fbc", "ab88a1ac-3e70-46ae-b045-26717baa93a8", "198", "298" },
                    { "5891738f-9b8f-460f-8669-e12caee0eb91", "41000f1b-b781-4c64-80b1-d10e01b7ae84", "5eac6253-bc76-4d52-95ec-5de7901eb5a1", "126", "226" },
                    { "59838408-b420-43e4-956b-a7f65a3edc19", "1c113218-c521-4e60-921d-86f8eabe0137", "db289afe-2048-4b74-b83c-53a4d5ed6022", "163", "263" },
                    { "5c0ba168-cf9b-4715-a711-ed978a5aa6d9", "a809d0b8-1e52-44a4-a6f9-839f889ab40d", "02629ae1-6023-4995-96d8-699cb86e8a4e", "149", "249" },
                    { "5e249164-b4d5-4355-9d65-58daffcaaff0", "deb7f815-41b4-4ac4-b5b5-b9a7d8134add", "d1286225-8757-4510-bebc-2b1f522d9954", "190", "290" },
                    { "62a22fcb-97aa-4a5e-8fc7-3be61e651e9b", "864b85c8-3420-4eef-9b69-3ac8ca8d75a8", "303f209e-cd89-4705-a87b-416e2ac9132f", "192", "292" },
                    { "6614ba84-6b7e-47b4-85dd-d34a9c130a97", "647c7385-9cff-4d94-8f75-f9fa655aff36", "037a7db5-2a85-4f84-82c4-e4b7ee610d49", "131", "231" },
                    { "6bc51ab6-12f5-40ed-9969-d1d94e387e55", "6759c88c-c143-4e4c-9cb3-e6ed434b2845", "025e3879-507b-4ce5-b052-a22eb183740e", "159", "259" },
                    { "6f615209-8c3b-4a1f-9ea3-16a0aba312c4", "0c7af229-bbd2-4ef0-9e0a-a297710a504b", "4e8fa5df-04b9-473d-a405-3ff08becf159", "179", "279" },
                    { "6f8ae824-f993-416f-89a2-d0a2152361f7", "d74049b0-7606-47cd-a3b8-c60b4479be80", "984d98bf-55ec-4e75-a0ee-db9da5fe547f", "175", "275" },
                    { "701d0a59-2ef0-4ebe-b8a8-e3fdeb37bdab", "9c64db94-347a-4d23-8430-e21e90052cd2", "0d961058-a3f0-4b02-a8e5-9c2712a38935", "139", "239" },
                    { "73e30d06-8a52-4366-a506-b523e26f01d2", "6661786a-a76a-42db-9fea-a2f7fcaa896d", "551e094d-d6a7-4a06-b62f-2b3d466e4376", "127", "227" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Units", "UnitsPrice" },
                values: new object[,]
                {
                    { "7c52f9c6-5140-4f0e-b577-e801cb2b8c66", "16b72e34-d406-4a48-88b4-ecdcdd0d5728", "39ae7e77-1422-4e56-8e4e-04a5f1a7e08a", "128", "228" },
                    { "80129b81-8274-419d-bc9e-401f5d698629", "8ce2f287-2337-4231-99c9-b9b73f3fa26e", "9e707e3b-d644-48ad-a8a6-0bffb64c3b3c", "129", "229" },
                    { "88a01f85-4038-4265-9615-0fbf231dd8c4", "2ef8a040-3fd7-4474-90a8-3c487e63ef0f", "b068d9fe-67a6-4640-bbb2-79e9e5ff7fdf", "118", "218" },
                    { "88c73145-b32c-4d35-97bb-bf8434c6329f", "ea670384-2d82-4839-a938-d3df934cf98d", "48107283-c62a-4c2d-817e-96349e0db64c", "141", "241" },
                    { "8bc427f4-133d-4ec2-a8d9-a6dda8adea66", "5909ec24-7955-4207-950f-40d60ae654e4", "378a3aee-86a2-4ba6-ac3d-a3b4a591e8c4", "121", "221" },
                    { "8d4fee45-7977-4a20-a547-2bae1f1b3fc0", "69c323ad-192c-4961-82c2-dd1e578d5905", "bf5525a9-d47c-4008-91a2-3d77f6b72093", "169", "269" },
                    { "8eaa9adf-4677-4cab-8285-9c8608be59ba", "24d362e5-11a3-4bf6-99ac-73d3bbb310fd", "16d6a51e-5781-43a6-b61c-463ff4885041", "148", "248" },
                    { "926fcb7e-ea08-4298-84be-8ff0e4bc65b9", "de5c42e8-a230-420c-914e-b852a350f668", "89197b8d-e7ce-40dc-ab1a-8127e24d8e6d", "160", "260" },
                    { "944268fd-10b6-4c89-bf22-a6a267f21d5c", "640370f8-56d1-44ff-9c3c-ba45e24dd728", "0a71749f-fca2-46d1-802e-cf92244b7830", "109", "209" },
                    { "9725de03-c0c0-4c25-8628-12a4c3013108", "806aa546-6ff0-4839-ac4a-b5cfa8b9ce61", "c9c51203-c5d1-4282-8a85-3c511ae1f53e", "124", "224" },
                    { "9c12a38b-a953-4298-a229-d1677c9589b0", "58452626-da83-4094-b47e-3d71bfb39364", "6a3bd086-6077-432c-9b57-ec32cfff2702", "136", "236" },
                    { "9c4d3670-67cf-4295-b904-13f952d511c7", "244e1705-8436-4595-8f5f-e4c3f8ee46db", "67aedc61-c828-4b4b-b8ff-d24953ad57c6", "195", "295" },
                    { "9e684bf7-1e8c-453d-ad2b-59ef8821eef1", "79a766d2-5cc6-446d-937b-54682a86d0db", "f932c5a9-dc6d-46cb-b6ac-dc7d11770faf", "125", "225" },
                    { "a1af2424-c066-4bac-b64b-fbdd27e656f9", "a60c44a0-90c5-4412-bdfa-6358d9006aa4", "cb9939c2-ae40-4c33-902d-e0396411360d", "199", "299" },
                    { "a2c2ba21-a667-4573-9a11-72bf82349429", "5571032d-c247-4949-b5a8-8e1f0e188e21", "a17c83a5-aa3f-42f6-917f-22d19501bfb7", "168", "268" },
                    { "a473b762-c9ef-4596-82e4-f4fb7f72add0", "d235787c-5820-4896-aeec-77c189d6ae7b", "c1eda093-7975-464d-b13d-d04f38e29bf6", "145", "245" },
                    { "a4fcc1ad-c3bd-47c3-8c3b-9fbf213130cd", "ea2ea746-67b9-44cd-9727-eca7a06ef710", "5d7d09fd-6a66-450e-951b-b03b6adddac3", "178", "278" },
                    { "a6340bb5-8a8f-4fb1-ac09-41bfa9f192a4", "ee0e34ac-cd4a-4b4d-9a3b-dd84ca45f4a6", "c8f155c0-8958-494e-b4a6-aeb37ba8aef3", "194", "294" },
                    { "a8b2a332-ed5b-4bf5-9a6d-4d655e0a01db", "6f646a98-3e97-4e75-9ba3-d73d72e74d12", "4b9543c1-4086-41be-a917-950ca47c6fb3", "196", "296" },
                    { "aa3213c5-4be4-424d-b4aa-e6cc05e277b8", "6cc474f1-1254-4dc2-933e-f3650dca97d9", "5f903e8a-24a9-4b22-b6cd-17253be1a302", "122", "222" },
                    { "aac1f9ca-5213-4f1a-8109-8c95d2d72f4d", "6632a15d-1d19-45f2-9290-868e349dbd56", "eb27794e-0aff-4b17-a58a-e7980bfc4dab", "173", "273" },
                    { "ad0fadb0-83a9-41b0-b27f-4ef90583363f", "3c21170c-941a-4c1a-b659-e96752f1a6e7", "fa39579a-32b9-4ff8-b336-26c18eb2efcd", "114", "214" },
                    { "ae4e426e-b3d7-4eb8-9c03-39b6cd1f60fe", "a995b4cc-0bb1-4ffb-9620-eed1ba39503f", "dd99cd7a-4043-47b6-ae71-82f7fb94ff04", "170", "270" },
                    { "aeb74811-ef0c-4a07-8113-8cc79e028484", "4c7ce33e-82be-4bd1-8bda-ba62b79eb43f", "97632a32-ffa4-4dd2-8d10-f599c118ba17", "115", "215" },
                    { "b2ce4f68-aa28-45e5-9fb2-51eedcda1d57", "bdd43f47-dcfe-44c6-807f-782a54f83f0b", "598b77c7-8435-4b95-83af-5925eca8a309", "154", "254" },
                    { "b607b2b0-ddb7-406e-b192-3dd75a17f78c", "66e86ce5-05a2-4120-90c3-89ab62465f1c", "d912081b-ed3d-453e-995f-ed8cc1ed331d", "140", "240" },
                    { "b644828e-90e9-411f-97ab-1805ed816db6", "4b3cf246-78cc-4ae6-b203-9f30ab39bc1a", "df5bddf3-0477-4853-bc6f-8644b230d55f", "133", "233" },
                    { "b67ad347-5adf-42ad-b7e3-3c41f6a6b26d", "10e647a2-3a7c-4acf-af79-962972f33037", "9b6ed588-895c-486c-bf14-8db417a39659", "183", "283" },
                    { "bde2de82-38ac-4017-a554-19fb2515238d", "03e8befc-4938-4eae-9b25-92db874665ed", "583a0118-dd4c-49a5-b5df-273f79fc5029", "176", "276" },
                    { "bebd6548-d55f-4f97-9eb8-dcd2d3a9a2d5", "85618ec4-5b4b-487d-95ce-db47e1fda15a", "7594b50e-b4a5-4ccb-95db-429f215188d6", "150", "250" },
                    { "c14ba747-8b95-463c-823f-c443c047ad34", "0de21f94-c617-46f7-872f-e8603e4f3480", "c9db4542-db83-431d-b02f-34a3d710d418", "116", "216" },
                    { "c39d96f6-f84f-4d5b-96c1-9f74fd0497c4", "6ab87df3-54d6-4d13-889a-a3f102ee7e2e", "a9389c42-61b6-41b3-915e-0f23b1e6f0bc", "151", "251" },
                    { "c70e9c35-343d-4da0-856e-c70048d26bd0", "98e3ba92-658b-43a3-be7a-01cc5aab19de", "27e7b92d-40bb-41f2-a772-b6a9cbcb48a2", "112", "212" },
                    { "cdb3e76e-716a-4a36-8873-102ac1dcd5c6", "d7c766c3-443d-4c1a-82dd-cf809a34db72", "522be689-e46a-4b1b-8cb3-519eed0b83b0", "189", "289" },
                    { "cea85eb6-3eef-48da-929c-ad59f50ba3cf", "8cf7f28d-8c72-48cf-bbc0-215fc1b17628", "07376fc5-e41d-4f4c-893c-dbd514b61a5f", "191", "291" },
                    { "d05c2a20-af94-4b56-b911-c6a1d0ab92b0", "a5593fac-82dc-4e53-a64b-4f1c89649197", "2d36d386-573d-4fd3-8f9c-a7b337dd1b5f", "100", "200" },
                    { "d5c84a60-7fe0-494e-8e52-354df8458047", "0b538536-7030-4e71-b6b9-4d0732fa5dd9", "d270a269-9821-4d1d-b512-06d2b107f041", "137", "237" },
                    { "d63bfeab-2a24-4830-a387-f44fd85472ad", "725a6922-5ea7-4f88-85e3-4b38d9a40f5b", "f134dbb6-a95b-493f-8cd7-c7d54b29df28", "107", "207" },
                    { "d8c5fb97-c004-4083-9222-f609c8630144", "3474d1f8-9372-4790-9d73-904bb5be4212", "b89d966b-90fe-44ee-a460-0367bbf0d34a", "181", "281" },
                    { "d9cb50e6-2d67-4d78-a575-3a16d06e3c24", "0b1e293f-e4b0-4045-a1cf-abdd31f03d8e", "264e83c1-c774-4cab-8a15-8b311c3f77c9", "174", "274" },
                    { "da7e8c7c-2dfc-4c5b-b27d-c942f5c33f09", "7af662d6-1e2b-40b2-9043-d966bdf68bc9", "a5f07117-1748-4dee-a10d-6573a1db8e0e", "108", "208" },
                    { "dad34742-6cde-4c90-a0f0-0a63c0fa1aad", "580ce179-a426-4e61-81ae-0d20f8e6e8b0", "3d42be8d-ebeb-461a-b395-89c0b98e51db", "101", "201" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Units", "UnitsPrice" },
                values: new object[,]
                {
                    { "ded26e15-1bae-4093-b670-d6934badca8a", "f297d8ed-97d9-420b-b57a-2475806e8039", "3b055416-9d9f-4572-bc45-926a9fb8005a", "153", "253" },
                    { "e059c2cc-4f7b-44c4-abbd-8831c16f784d", "4c359f18-d169-4f05-a193-bc366bd3976a", "3885f003-402f-4fa9-b7af-e90d370712b4", "142", "242" },
                    { "e0a09071-e52f-4ea9-ac69-c86fe2e98b1b", "47e729a2-8c0c-4cc0-afb6-c249f4a5ac4e", "e4f60708-08f6-4372-b534-9d413c0bbbbc", "188", "288" },
                    { "e12644c5-68d3-44ef-9220-8593131f2c51", "25c10fe7-92be-4b27-810c-e3aa35c037ce", "5ad860d4-a82f-49c2-befc-7f52ab96ef07", "130", "230" },
                    { "e24c974b-2cb9-432f-ac28-7780bf6cd940", "d7c4e026-ecc3-4be2-9a81-8fbfc87bef5a", "bc9a1e7e-fa6d-456a-9025-2ece054b4c91", "182", "282" },
                    { "f2650dde-864b-48be-98d2-357d28f631ff", "c453129b-d199-455f-9ac6-8bd39cada04c", "54d57559-ea33-4936-a176-56701769e384", "119", "219" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderItem");
        }
    }
}
